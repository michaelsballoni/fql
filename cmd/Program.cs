using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace fql
{
    class Program
    {
        [STAThread]
        static async Task<int> Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: <directory path>");
                return 0;
            }

            string dirPath = args[0].Trim();
            if (!Directory.Exists(dirPath))
            {
                Console.WriteLine("ERROR: Directory does not exist: {0}", dirPath);
                return 1;
            }

#if !DEBUG
            try
#endif
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Commands: reset, update, search, quit");

                    Console.WriteLine();
                    Console.Write("> ");

                    string line = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    Console.WriteLine();

                    if (line == "reset")
                    {
                        SearchInfo.Reset();
                        Console.WriteLine("DB reset");
                    }
                    else if (line == "update")
                    {
                        var updateResult = 
                            SearchInfo.UpdateAsync
                            (
                                new List<string> { dirPath }, 
                                new List<string>(), 
                                OnDirectoryUpdate
                            ).Result;
                        Console.WriteLine("DB updated: files added: {0} - removed: {1} - modified: {2} - indexed: {3}", 
                                          updateResult.filesAdded, 
                                          updateResult.filesRemoved, 
                                          updateResult.filesModified,
                                          updateResult.indexSize);
                    }
                    else if (line.StartsWith("search "))
                    {
                        var results = await SearchInfo.SearchAsync(line.Substring("search ".Length).Trim());
                        Console.WriteLine($"Search results: {results.Count}");
                        foreach (var result in results)
                            Console.WriteLine(result);
                    }
                    else if (line == "quit")
                    {
                        Console.WriteLine("Quitting...");
                        break;
                    }
                }
            }
#if !DEBUG
            catch (Exception exp)
            {
                Console.WriteLine("EXCEPTION: {0}", exp);
                return;
            }
#endif
            Console.WriteLine("All done.");
            return 0;
        }

        static void OnDirectoryUpdate(UpdateInfo update)
        {
            Console.WriteLine(update.ToString());
        }
    }
}
