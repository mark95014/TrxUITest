using Newtonsoft.Json;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace TrxUITest.src.utils.PageData.Elements
{
    public abstract class GridElement : Element
    {
        //[JsonIgnore]
        //public List<List<Object>> dataList;
        
        //private int rownum = 0;

        public GridElement(string selector = "") : base(selector) {
            TestContext.Progress.WriteLine($"GridElement constructor selector = {selector}");
            //TestContext.Progress.WriteLine($"GridElement constructor rownum = {rownum}");
        }

        public abstract void GetCell(IWebElement element, List<Object> row, int columnNumber);

        public abstract Result VerifyCell(Object actualResult, Object expectedResult, string msg, int colnumber);

        public override void Get()
        {
            GetGrid(selector);
        }

        public override void GetByWebElement(IWebElement webElement)
        {
            Get();
        }

        private void GetGrid(string gridWrapperSelector)
        {
            Thread.Sleep(2000);

            IWebElement wrapperElement = Test.driver.FindElement(By.CssSelector(gridWrapperSelector));

            //string nextPageSelector = gridWrapperSelector + " *[id*=page-next]";
            //string pageCountSelector = gridWrapperSelector + " *[id*=pagecount]";
            //string scrollbarSelector = gridWrapperSelector + " div.tg-scrollbar";
            string nextPageSelector = "*[id*=page-next]";
            string pageCountSelector = "*[id*=pagecount]";
            string scrollbarSelector = "div.tg-scrollbar";
            Thread.Sleep(500);

            ReadOnlyCollection<IWebElement> pageCountElements = wrapperElement.FindElements(By.CssSelector(pageCountSelector));

            //some page have the element in DOM, but it's not visible, so don't do paging for these grids.
            //bool pageCountVisible = SeleniumHelpers.WaitForElementToBeVisible(pageCountSelector, 5);

            if (pageCountElements.Count > 0)
            { //paging controls loop
                int pageCount = int.Parse(pageCountElements[0].Text);
                if (pageCount <= 0) pageCount = 1;
                int pagelen = 10;
                int ix = 0;

                data = new List<List<Object>>();

                for (; pageCount > 0; pageCount--)
                {
                    GetPage(wrapperElement);
                    if (pageCount > 1)
                    {
                        Test.driver.FindElement(By.CssSelector(nextPageSelector)).Click();
                    }
                    ix += pagelen;
                }
            }
            else
            {
                ReadOnlyCollection<IWebElement> scrollbarElements = Test.driver.FindElements(By.CssSelector(scrollbarSelector));

                if (scrollbarElements.Count > 0)
                { //scrollbar loop
                    const string firstRow = "div.tg-row.tg-level-0.tg-even.tg-pane-first.tg-list-first";
                    Test.driver.FindElement(By.CssSelector(firstRow)).Click();
                    bool lastPage = false;

                    int pageCount = 0;
                    int rownumber = 0;

                    data = new List<List<Object>>();

                    while (!lastPage && pageCount < 5)
                    {
                        GetPage(wrapperElement);
                        pageCount++;
                        rownumber += 10;
                        const string lastRow = ".tg-row.tg-pane-last.tg-list-last";
                        IWebElement lastRowElement = Test.driver.FindElement(By.CssSelector(lastRow));
                        if (lastRowElement != null)
                        {
                            lastPage = true;
                        }
                        else
                        {
                            scrollbarElements[0].SendKeys(Keys.PageDown);
                        }
                    }
                    RemoveDuplicates(); //scrolled page can produce dups
                }
                else
                {
                    //single page, no scrollbar, no paging controls
                    data = new List<List<Object>>();
                    GetPage(wrapperElement);
                }
            }

            //data = dataList;
            //List<List<Object>> tempData = (List<List<Object>>)data;
            //if (tempData == null) TestContext.Progress.WriteLine($"At end of GridElement.GetGrid data is null");
            //else TestContext.Progress.WriteLine($"At end of GridElement.GetGrid data count = {tempData.Count}");
        }

        private void GetPage(IWebElement wrapper)
        {
            //TestContext.Progress.WriteLine($"GetPage starting value for rownum {rownum}");
            //TestContext.Progress.WriteLine($"GetPage starting length of dataList {dataList.Count}");

            const string rowsSelector = "div.tg-row";
            const string cellsSelector = "div.tg-cell";
            Thread.Sleep(2000);

            ReadOnlyCollection<IWebElement> rows = wrapper.FindElements(By.CssSelector(rowsSelector));
            TestContext.Progress.WriteLine($"GetPage number of rows = {rows.Count}");

            foreach (IWebElement row in rows)
            {
                ReadOnlyCollection<IWebElement> cells = row.FindElements(By.CssSelector(cellsSelector));
                TestContext.Progress.WriteLine($"GetPage number of cells = {cells.Count}");

                ((List<List<object>>)data).Add(new List<object>());

                foreach (IWebElement cell in cells)
                {
                    //TestContext.Progress.WriteLine($"GetPage rownum, index of cell = {this.rownum}, {cells.IndexOf(cell)}");
                    //TestContext.Progress.WriteLine($"GetPage length of dataList = {data.Count}");
                    int count = ((List<List<object>>)data).Count;
                    GetCell(cell, ((List<List<object>>)data)[count - 1], cells.IndexOf(cell)); //??? can we use cells.Count - 1 ?
                }
                //TestContext.Progress.WriteLine($"GetPage incrementing rownum from {rownum} to {rownum+1}");
                //this.rownum++;
            }
        }

        private void RemoveDuplicates()
        {
            //List<JToken> list = jObj["quote"].GroupBy(x => x["id"]).Select(x => x.First()).ToList();
        }

        public override Result Verify(string name, Object expected) //???add dataLabel as a parameter
        {
            List<List<Object>> expectedResult = JsonConvert.DeserializeObject<List<List<Object>>>(expected.ToString());

            int actualRowCount = (data == null) ? 0 : ((List<List<object>>)data).Count;
            int expectedRowCount = (expectedResult == null) ? 0 : expectedResult.Count;

            if (actualRowCount != expectedRowCount)
            {
                string msg = $"Number of actual and expected rows are not the same. Name: {name} Actual: {actualRowCount} Expected: {expectedRowCount}";
                TestContext.Progress.WriteLine(msg);
                Test.results.Add(new Result(false, msg));
            }
            else
            {
                string message = $"Number of actual and expected rows are the same. Actual: {actualRowCount} Expected: {expectedRowCount}";
                TestContext.Progress.WriteLine(message);

                if (expectedRowCount > 0)
                {
                    int rownumber = 0;

                    foreach (List<object> row in expectedResult)
                    {
                        if (row != null)
                        {
                            int colnumber = 0;

                            foreach (object column in row)
                            {
                                if (column != null)
                                {
                                    var columnCount = ((List<List<object>>)data)[rownumber].Count;
                                    if (colnumber >= columnCount || ((List<List<object>>)data)[rownumber][colnumber] == null)
                                    {
                                        string msg = $"{name}: Missing actual result for column expected result: {column}";
                                        Test.results.Add(new Result (false, msg));
                                    }
                                    else
                                    {
                                        string msg = $"{name}: actual= {((List<List<object>>)data)[rownumber][colnumber]} expected= {column}";
                                        Test.results.Add(VerifyCell(((List<List<object>>)data)[rownumber][colnumber], column, msg, colnumber));
                                    }
                                }
                                colnumber++;
                            }
                        }
                        rownumber++;
                    }
                }
            }
            return new Result (true, ""); //Results are added for each cell. This is just to satisfy inherited method requirement.
        }
    }
}
