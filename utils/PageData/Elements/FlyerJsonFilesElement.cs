using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest
{

    public class FlyerJsonFilesElement : Element
    {
        public FlyerJsonFilesElement() : base("")
        {
        }

        public void TestCase8186()
        {
            FlyerJsonFilesElement el = new FlyerJsonFilesElement();
            el.Get();
            string dataLabel = ExpectedResults.MakeDataLabel(el.data, 3224607);
            JObject expectedResults = (JObject)JsonConvert.DeserializeObject(File.ReadAllText(ExpectedResults.fileName));
            JObject expectedResult = (JObject)expectedResults[dataLabel];
            el.Verify("flyer json", expectedResult);
        }

        private JArray SortFlyerJson(JArray unsorted)
        {
            return new JArray(unsorted
                    .OrderBy(obj => (string)obj["custodialAccount"])
                    .ThenBy(obj => (string)obj["symbol"])
                    .ThenBy(obj => (double)obj["amount"]));
        }

        public override Result Verify(string message, object expectedResult)
        {
            var ok = true;
            var diffs = new List<JToken>();
            var ix = 0;
            List<JArray> dataList = (List<JArray>)data;
            var jdp = new JsonDiffPatch();
            List<JArray> expectedResultArray = (List<JArray>)expectedResult;

            Console.WriteLine("actual length: " + dataList.Count);
            Console.WriteLine("expected length: " + (expectedResult as object[]).Length);

            foreach (JArray actualResult in dataList)
            {
                List<JArray> sortedExpectedResult = new List<JArray>();
                JArray sortedArray = SortFlyerJson(expectedResultArray[ix]);

                var diff = jdp.Diff(actualResult, expectedResultArray[ix++]);

                if (diff != null)
                {
                    ok = false;
                    diffs.Add(diff);
                    ix++;
                }

                Console.WriteLine("flyerJsonFilesElement ok: " + ok);

                if (!ok)
                {
                    Console.WriteLine("=========================================flyer diffs=====================================================");
                    foreach (var delta in diffs)
                    {
                        Console.WriteLine("diff: " + delta);
                    }

                    Assert.That(ok, Is.True, "flyerJsonFilesElement");
                    //Assert.Fail();
                }
            }

            return new Result(true);
        }

        public bool IsWindows()
        {
            var windowsHome = Environment.GetEnvironmentVariable("HOMEPATH");

            return !string.IsNullOrEmpty(windowsHome);
        }

        public override void Get()
        {
            string rootDirName;

            if (Test.webURL.Contains("localhost"))
            {
                rootDirName = "C:\\FIX\\JSON";
            }
            else if (Test.webURL.Contains("morningstar.com"))
            {
                rootDirName = "\\\\morningstar.com\\shares\\trxuatfileshare\\Flyer\\JSON\\" + Test.databaseName;
            }
            else
            {
                Assert.Fail("invalid launch_url: " + Test.webURL);
                return;
            }

            var dirName = rootDirName + "\\" + DateTime.Now.Year;
            //Thread.Sleep(30000);

            var fileNames = Directory.GetFiles(dirName);
            data = new List<JArray>();

            foreach (var fileName in fileNames)
            {
                var json = File.ReadAllText(fileName);
                JArray sortedArray = SortFlyerJson(JArray.Parse(json));
                ((List<JArray>)data).Add(sortedArray);
                // File.Delete(fileName);
            }

            //data = dataList;
            // Directory.Delete(dirName);
            // Directory.Delete(rootDirName);
        }

        public override void GetByWebElement(IWebElement webElement)
        {
            throw new NotImplementedException();//Should not be called
        }
    }
}