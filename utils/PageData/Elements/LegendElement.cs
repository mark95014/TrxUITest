using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.tests.utils
{
    public class LegendElement : Element
    {
        public LegendElement(string selector) : base(selector)
        {
        }

        public override void GetByWebElement(IWebElement webElement)
        {
            Get();
        }

        public override void Get()
        {
            ReadOnlyCollection<IWebElement> elements = Test.driver.FindElements(By.CssSelector(selector));
            string[] values = new string[elements.Count];
            int ix = 0;
            foreach(IWebElement element in elements)
            {
                values[ix++] = element.Text;
            }

            data = values;
        }

        public override Result Verify(string name, object expectedResult)
        {
            string[] dataArray = (string[])data;
            JArray jArray = (JArray)expectedResult;
            string[] expectedArray = jArray.Select(j => (string)j).ToArray();

            int actualCellCount = (data == null) ? 0 : dataArray.Length;
            int expectedCellCount = (expectedResult == null) ? 0 : expectedArray.Length;

            if (actualCellCount != expectedCellCount)
            {
                string prefix = "Number of actual and expected cells are not the same. Actual: ";
                string message = prefix + JsonConvert.SerializeObject(data) + " Expected: " + JsonConvert.SerializeObject(expectedResult);//???error inject
                Test.results.Add(new Result (false, message));
            }
            else
            {
                foreach(Object cell in expectedArray)
                {
                    int cellnum = Array.IndexOf(expectedArray, cell);
                    string message = name + ": " + "actual=" + dataArray[cellnum].ToString() + " expected=" + cell;
                    if (dataArray[cellnum].Equals(cell)) Test.results.Add(new Result(true, message));
                    else Test.results.Add(new Result(false, message));
                }
            }

            return new Result (!Test.results.HasFailures(), ""); //??? what happens to this Result?
        }
    }
}