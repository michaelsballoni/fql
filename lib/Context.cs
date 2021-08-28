using System;
using System.IO;

using metastrings;

namespace fql
{
    public static class msctxt
    {
        public static Context GetContext()
        {
            return new Context(DbFilePath);
        }

        public static void Reset()
        {
            File.Delete(DbFilePath);
            using (var ctxt = GetContext())
                NameValues.Reset(ctxt); // clear caches
        }

        public static string DbFilePath =
            Path.Combine
            (
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "fql.db"
            );
    }
}
