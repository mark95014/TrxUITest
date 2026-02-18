using TestContext = NUnit.Framework.TestContext;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading;
using TrxUITest.src.utils;
using Assert = NUnit.Framework.Assert;

namespace TrxUITest.src.pages
{
    public static class AnalysisPageTestBase
    {
        //enum Checkbox { oob, cash, tlh, openProposals }
        public enum Checkbox { oob, cash, tlh, openProposals }

        private static Checkbox[] allCheckboxes = {Checkbox.oob, Checkbox.cash, Checkbox.tlh, Checkbox.openProposals };

        public static void Refresh()
        {
            SeleniumHelpers.FindElement(AnalysisPage.Selectors.refreshButton).Click();
            AnalysisPage.WaitForPageToLoad();
        }

        public static void ColumnSortTestCase(string columnSelector)
        {
            AnalysisPage.GoTo();
            Refresh();
            AnalysisPage.WaitForPageToLoad();
            Thread.Sleep(1000);
            DefaultSort();
            SetCheckBoxes(new Checkbox[] { Checkbox.oob, Checkbox.cash, Checkbox.tlh });
            AscendingSort(columnSelector);
            Thread.Sleep(1000);
            AnalysisPage.VerifyPage();
        }

        //Clicking the column header the first time might result in an ascending or descending sort; it's not predictable.
        //So, we look for the up arrow. If found, we have an ascending sort and we exit. Otherwise, we click the column
        //header again which should give an up arrow and the sort will be ascending. If the 2nd click does not give an
        //up arrow, we fail the test case.
        public static void AscendingSort(string columnSelector, int retryCount = 0)
        {
            TestContext.Progress.WriteLine($"AscendingSort {retryCount}");
            SeleniumHelpers.FindElement(columnSelector).Click();

            string upArrow = ".tg-sort-placeholder.tg-sort-asc";
            ReadOnlyCollection<IWebElement> elements = SeleniumHelpers.FindElements(upArrow);

            if (elements.Count == 0) 
            {
                if (retryCount == 1)
                {
                    Assert.Fail("Up Arrow not found.");
                }
                else
                {
                    Thread.Sleep(1000);
                    AscendingSort(columnSelector, 1);
                }
            }
            AnalysisPage.WaitForPageToLoad();
        }

        public static void DefaultSort()
        {
            AscendingSort(AnalysisPage.Selectors.idSort);
        }

        public static void FilterTestCase(string columnSelector, string columnValue)
        {
            AnalysisPage.GoTo();
            Refresh();
            SetCheckBoxes(allCheckboxes);
            SeleniumHelpers.FindElement(columnSelector).SendKeys(columnValue);
            AnalysisPage.WaitForPageToLoad();
            DefaultSort();
            AnalysisPage.VerifyPage();
        }

        public static void FilterByMix()
        {
            AnalysisPage.GoTo();
            Refresh();
            SeleniumHelpers.FindElement(AnalysisPage.Selectors.model).SendKeys("60/40");
            SeleniumHelpers.FindElement(AnalysisPage.Selectors.classOOBPercent).SendKeys("3");
            SeleniumHelpers.FindElement(AnalysisPage.Selectors.advisor).SendKeys("SR");
            AnalysisPage.WaitForPageToLoad();
            DefaultSort();
            AnalysisPage.VerifyPage();
        }

        private static void SetCheckBoxes(Checkbox[] checkboxes) 
        {
            Checkbox[] allBoxes = { Checkbox.oob, Checkbox.cash, Checkbox.tlh, Checkbox.openProposals };
            foreach (Checkbox box in allBoxes)
            {
                //Use reflection to get the selector for the checkbox from the enum value
                FieldInfo field = typeof(AnalysisPage.Selectors).GetField(box.ToString());
                string selector = (string)field.GetValue(null);
                CheckboxElement checkboxElement = new CheckboxElement(selector);
                if (checkboxes.Contains(box)) checkboxElement.Check(); else checkboxElement.UnCheck();
            }
            AnalysisPage.WaitForPageToLoad();
        }

        public static void CheckboxTestCase(Checkbox[] checkboxes)
        {
            AnalysisPage.GoTo();
            Refresh();
            SetCheckBoxes(checkboxes);
            DefaultSort();
            AnalysisPage.VerifyPage();
        }
    }
}