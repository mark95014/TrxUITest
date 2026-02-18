using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.utils.PageData.Elements
{
    public class CsvElement : SimpleGridElement
    {
        private string csvFileName = null;
        private readonly string[] ignore = new string[0];

        public CsvElement(string selector, string csvFileName = "", params string[] ignore) : base(selector)
        {
            this.csvFileName = csvFileName;
            this.ignore = ignore;
        }

        public CsvElement(string selector) : base(selector)
        {
        }

        public override void Get()
        {
            GetByWebElement(Test.driver.FindElement(By.CssSelector(selector)));
        }

        public override void GetByWebElement(IWebElement webElement)
        {
            if (csvFileName == null) csvFileName = webElement.Text;

            if (selector.Length != 0) webElement.Click();
            else webElement.FindElement(By.CssSelector("span > a")).Click();
            Thread.Sleep(5000); //Wait for download
            string csvFilePath;
            if (Docker.RunningInContainer()) csvFilePath = "/app/downloads/" + csvFileName;
            else csvFilePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads\" + csvFileName;
            ParseCSV(csvFilePath);
            Cleanup(csvFilePath);
        }

        private class Comparer : IComparer<List<object>>
        {
            public int Compare(List<object> x, List<object> y)
            {
                foreach (object obj in x!)
                {
                    string xstr = obj!.ToString()!;
                    string ystr = y![x.IndexOf(obj)!]!.ToString()!;
                    int compareResult = xstr.CompareTo(ystr);
                    if (compareResult != 0) return compareResult;
                }

                return 0;
            }
        }

        private void RemoveHeader(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            File.WriteAllLines(fileName, new ArraySegment<string>(lines, 1, lines.Length - 1));
        }

        private void WaitForFileExists(string filePath, int waitSeconds)
        {
            while (waitSeconds > 0)
            {
                try
                {
                    FileStream file = File.OpenRead(filePath);
                    file.Close();
                    TestContext.Progress.WriteLine($"{filePath} was found.");
                    return;
                }
                catch (FileNotFoundException)
                {
                    TestContext.Progress.WriteLine($"Waiting for {filePath} to exist.");
                    waitSeconds--;
                    Thread.Sleep(1000);
                }
            }
        }

        private void ParseCSV(string csvFilePath)
        {
            bool hasHeaders = csvFilePath.ToUpper().Contains("PERSHING");
            this.WaitForFileExists(csvFilePath, 60);
            if (hasHeaders) RemoveHeader(csvFilePath);

            data = new List<List<object>>();

            using (CsvReader csv = new CsvReader(new StreamReader(csvFilePath), false))
            {
                int fieldCount = csv.FieldCount;

                while (csv.ReadNextRecord())
                {
                    List<Object> fields = new List<Object>();

                    for (int i = 0; i < fieldCount; i++)
                    {
                        fields.Add(csv[i]);
                    }

                    ((List<List<object>>)data).Add(fields);
                }
            }

            ((List<List<object>>)data).Sort(new Comparer());
            TestContext.Progress.WriteLine(csvFilePath);
            TestContext.Progress.WriteLine(data);
        }

        private void Cleanup(string fileName)
        {
            TestContext.Progress.WriteLine($"Deleting {fileName}");
            File.Delete(fileName);
        }

        private void EraseTrxUserName()
        {

        }
    }
}
//eraseTrxUserName(trxUserName: string) { //Remove the Trx user name occurences from the data because these change each time a test is run.
//    var rownum: number = 0
//        for (let row of this.data)
//    {
//        var rowstr: string = row
//            var colnumber: number = 0
//            for (let column of row)
//        {
//            var colstr: string = column
//                if (typeof(colstr) == 'string')
//            {
//                if (colstr.includes(trxUserName))
//                {
//                    this.data[rownum][colnumber] = colstr.replace(trxUserName, '')
//                    }
//            }
//            colnumber++
//            }
//        rownum++
//        }
//}
