using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fql
{
    [TestClass]
    public class SearchInfoTests
    {
        [TestMethod]
        public void TestSearchInfo()
        {
            SearchInfo.Reset();

            // Populate
            {
                var addedRemoved =
                    SearchInfo.UpdateAsync
                    (
                        new List<string> { Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) },
                        new List<string>(),
                        TestUpdater
                    ).Result;
                Assert.AreNotEqual(0, addedRemoved.filesAdded);
                Assert.AreEqual(0, addedRemoved.filesRemoved);
                Assert.AreEqual(0, addedRemoved.filesModified);
            }

            // Query
            int firstResultCount;
            {
                var results = SearchInfo.SearchAsync("Videos").Result;
                Assert.AreNotEqual(0, results.Count);
                firstResultCount = results.Count;
                Console.WriteLine("results: {0}", results.Count);
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                    Assert.IsTrue(result.StartsWith(SearchInfo.UserRoot));
                    Assert.IsTrue(File.Exists(result));
                }
            }

            // Update
            {
                var addedRemoved =
                    SearchInfo.UpdateAsync
                    (
                        new List<string> { Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) },
                        new List<string>(),
                        TestUpdater
                    ).Result;
                Assert.AreEqual(0, addedRemoved.filesAdded);
                Assert.AreEqual(0, addedRemoved.filesRemoved);
                Assert.AreEqual(0, addedRemoved.filesModified);
            }

            // Query
            int secondResultCount;
            {
                var results = SearchInfo.SearchAsync("Videos").Result;
                Assert.AreNotEqual(0, results.Count);
                secondResultCount = results.Count;
                Console.WriteLine("results: {0}", results.Count);
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                    Assert.IsTrue(result.StartsWith(SearchInfo.UserRoot));
                    Assert.IsTrue(File.Exists(result));
                }
                Assert.AreEqual(firstResultCount, secondResultCount);
            }
        }

        private static void TestUpdater(UpdateInfo updateInfo)
        {
            Console.WriteLine(updateInfo.ToString());
        }
    }
}
