using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using metastrings;

namespace fql
{
    public class StopException : Exception
    {}

    public class FqlException : Exception
    {
        public FqlException(string msg)
            : base(msg)
        {}
    }

    public class DirProcessInfo
    {
        public Dictionary<string, long> filesLastModifiedInFs = new Dictionary<string, long>();
        public Dictionary<string, long> filesLastModifiedInDb = new Dictionary<string, long>();

        public UpdateInfo update;
        public DirectoryUpdate updater;

        // Path => file timestamp, search data
        public List<Tuple<string, long, string>> toAdd = new List<Tuple<string, long, string>>();

        // Paths to delete, as objects for direct metastrings delete
        public List<object> toDelete = new List<object>();

        public int filesAdded;
        public int filesRemoved;
        public int filesModified;

        public int indexSize;
    }

    public static class SearchInfo
    {
        public static Dictionary<string, string> GetFileMetadata(string filePath)
        {
            Dictionary<string, string> metadata = new Dictionary<string, string>();

            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder objFolder = shell.NameSpace(Path.GetDirectoryName(filePath));

            List<string> headers = new List<string>();
            for (int i = 0; i < short.MaxValue; ++i)
            {
                string header = objFolder.GetDetailsOf(null, i);
                if (string.IsNullOrEmpty(header))
                    break;

                headers.Add(header);
            }
            if (headers.Count == 0)
                return metadata;

            foreach (Shell32.FolderItem2 item in objFolder.Items())
            {
                if (!filePath.Equals(item.Path, StringComparison.OrdinalIgnoreCase))
                    continue;

                for (int i = 0; i < headers.Count; ++i)
                {
                    string details = objFolder.GetDetailsOf(item, i);
                    if (!string.IsNullOrWhiteSpace(details))
                        metadata.Add(headers[i], details);
                }
            }

            return metadata;
        } // GetFileMetadata()

        public static void Reset()
        {
            msctxt.Reset();
        }

        public static async Task<List<string>> SearchAsync(string query, int maxResults = -1)
        {
            var select = Sql.Parse("SELECT value FROM files WHERE searchdata MATCHES @search");
            select.limit = maxResults;
            select.AddParam("@search", query);
            // DEBUG
            //string sql = Sql.GenerateSqlAsync(msctxt.getctxt(), select).Result;

            List<string> results;
            using (var ctxt = msctxt.GetContext())
                results = await ctxt.ExecListAsync<string>(select);
            return results;
        }

        public static string UserRoot
        {
            get
            {
                if (sm_userRoot != null)
                    return sm_userRoot;

                sm_userRoot = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // My Documents
                sm_userRoot = sm_userRoot.Trim('\\');

                var pathParts = sm_userRoot.Split('\\');

                string userRoot = "";
                for (int p = 0; p < pathParts.Length - 1; ++p)
                    userRoot += pathParts[p] + "\\";

                sm_userRoot = userRoot;
                return sm_userRoot;
            }
        }
        private static string sm_userRoot;

        // Returns <added, removed, total left standing>
        public static async Task<DirProcessInfo> 
            UpdateAsync
            (
                List<string> includeDirPaths, 
                List<string> excludeDirPaths, 
                DirectoryUpdate updater = null
            )
        {
            ScopeTiming.Init(true);
            ScopeTiming.Clear();
            try
            {
                UpdateInfo update = new UpdateInfo("Updating search index...");
                updater?.Invoke(update);

                var dirProcInfo =
                    new DirProcessInfo()
                    {
                        update = update,
                        updater = updater
                    };

                List<string> dirPaths;
                update.Start("Collecting directories to index...");
                updater?.Invoke(update);
                {
                    var dirPathsSet = new HashSet<string>();
                    {
                        foreach (string includeDirPath in includeDirPaths)
                        {
                            dirPathsSet.Add(includeDirPath);
                            foreach (string subIncludeDirPath in Directory.GetDirectories(includeDirPath, "*", SearchOption.AllDirectories))
                                dirPathsSet.Add(subIncludeDirPath);
                        }

                        foreach (string excludeDirPath in excludeDirPaths)
                            dirPathsSet.RemoveWhere(p => Path.GetFullPath(p).StartsWith(Path.GetFullPath(excludeDirPath)));
                    }

                    dirPaths = new List<string>(dirPathsSet.Count);
                    dirPaths.AddRange(dirPathsSet);

                    dirPaths.Sort();
                }

                update.Start("Collecting files to index...", dirPaths.Count);
                updater?.Invoke(update);
                foreach (var dirPath in dirPaths)
                {
                    foreach (string filePath in Directory.GetFiles(dirPath, "*", SearchOption.TopDirectoryOnly))
                    {
                        long fileLastEpoch = GetEpochSeconds(new FileInfo(filePath).LastWriteTimeUtc);
                        dirProcInfo.filesLastModifiedInFs.Add(filePath, fileLastEpoch);
                    }

                    ++update.current;
                    if ((update.current % 100) == 0)
                        updater?.Invoke(update);
                }

                update.Start($"Getting indexed files...");
                updater?.Invoke(update);
                {
                    var select = Sql.Parse("SELECT value, filelastmodified FROM files");
                    using (var ctxt = msctxt.GetContext())
                    using (var reader = await ctxt.ExecSelectAsync(select))
                    {
                        while (await reader.ReadAsync())
                        {
                            string path = reader.GetString(0);
                            long lastModified = reader.GetInt64(1);
                            dirProcInfo.filesLastModifiedInDb.Add(path, lastModified);
                        }
                    }
                }

                update.Start($"Indexing directories...", dirPaths.Count);
                updater?.Invoke(update);
                var allFilePaths = new List<string>();
                {
                    allFilePaths.AddRange(dirProcInfo.filesLastModifiedInDb.Keys);
                    allFilePaths.AddRange(dirProcInfo.filesLastModifiedInFs.Keys);
                    foreach (var curDirPath in dirPaths)
                        allFilePaths.AddRange(Directory.GetFiles(curDirPath, "*", SearchOption.TopDirectoryOnly));
                    allFilePaths = allFilePaths.Distinct().ToList();
                }
                ProcessDirectory(allFilePaths, dirProcInfo);

                using (var ctxt = msctxt.GetContext())
                {
                    update.Start("Cleaning search index...", dirProcInfo.toDelete.Count);
                    updater?.Invoke(update);
                    await ctxt.Cmd.DeleteAsync("files", dirProcInfo.toDelete);

                    update.Start("Updating search index...", dirProcInfo.toAdd.Count);
                    updater?.Invoke(update);
                    foreach (var tuple in dirProcInfo.toAdd)
                    {
                        Define define = new Define("files", tuple.Item1);
                        define.metadata["filelastmodified"] = tuple.Item2;
                        define.metadata["searchdata"] = tuple.Item3;
                        await ctxt.Cmd.DefineAsync(define);

                        ++update.current;
                        if ((update.current % 100) == 0)
                            updater?.Invoke(update);
                    }
                }

                {
                    Select select = Sql.Parse("SELECT count FROM files");
                    using (var ctxt = msctxt.GetContext())
                        dirProcInfo.indexSize = Convert.ToInt32(await ctxt.ExecScalarAsync(select));
                }

                return dirProcInfo;
            }
            finally
            {
                File.WriteAllText
                (
                    Path.Combine
                    (
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "fql.timing.txt"
                    ), 
                    ScopeTiming.Summary
                );
            }
        }

        private static void ProcessDirectory(IEnumerable<string> allFilePaths, DirProcessInfo info)
        {

            List<string> filesToAdd = new List<string>();
            List<string> filesToRemove = new List<string>();

            foreach (string filePath in allFilePaths)
            {
                bool inDb = info.filesLastModifiedInDb.ContainsKey(filePath);
                bool inFs = info.filesLastModifiedInFs.ContainsKey(filePath);

                if (inDb && !inFs)
                {
                    ++info.filesRemoved;
                    filesToRemove.Add(filePath);
                    continue;
                }

                if (inFs && !inDb)
                {
                    ++info.filesAdded;
                    filesToAdd.Add(filePath);
                    continue;
                }

                if (!inDb && !inFs) // weird!
                {
                    ++info.filesRemoved;
                    filesToRemove.Add(filePath);
                    continue;
                }

                // else in both

                if (info.filesLastModifiedInDb[filePath] < info.filesLastModifiedInFs[filePath])
                {
                    ++info.filesModified;
                    filesToAdd.Add(filePath);
                    continue;
                }
            }

            info.toDelete.AddRange(filesToRemove.Select(f => (object)f));

            foreach (string filePath in filesToAdd)
            {
                string searchData =
                    filePath.Substring(UserRoot.Length)
                        .Replace(Path.DirectorySeparatorChar, ' ')
                        .Replace('.', ' ');
                while (searchData.Contains("  "))
                    searchData = searchData.Replace("  ", " ");
                searchData = searchData.Trim();

                long lastModified = info.filesLastModifiedInFs[filePath];
                info.toAdd.Add(new Tuple<string, long, string>(filePath, lastModified, searchData));
            }
        }

        private static long GetEpochSeconds(DateTime dt)
        {
            return (long)(dt - sm_epoch).TotalSeconds;
        }
        private static readonly DateTime sm_epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
