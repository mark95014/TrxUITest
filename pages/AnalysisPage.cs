using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class AnalysisPage
    {
        public static class Selectors
        {
            public readonly static string analysisTable = "#aeGrid";
            public readonly static string rebalanceButton = "#analysis-expert-multirebal-btn";
            public readonly static string cashRebalanceButton = "#analysis-expert-multicash-btn";
            public readonly static string tlhRebalanceButton = "#analysis-expert-multitlh-btn";
            public readonly static string oob = "#oob-checkbox";
            public readonly static string cash = "#cash-checkbox";
            public readonly static string tlh = "#tlh-checkbox";
            public readonly static string openProposals = "#include-proposals-switch";
            public readonly static string id = "#aeGrid-filter-DisplayId";
            public readonly static string clientName = "#aeGrid-filter-Description";
            public readonly static string model = "#aeGrid-filter-Model";
            public readonly static string advisor = "#aeGrid-filter-AdvisorSet";
            public readonly static string rebalanceSet = "#aeGrid-filter-AdvisorSet";
            public readonly static string value = "#aeGrid-filter-TotalValueMngd";
            public readonly static string classOOBPercent = "#aeGrid-filter-ClassOOBPct";
            public readonly static string classOOBAmount = "#aeGrid-filter-ClassOOBAmt";
            public readonly static string tlhFilter = "#aeGrid-filter-TLHFlag";
            public readonly static string idSort = "#aeGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div";
            public readonly static string clientSort = "#aeGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-1.tg-h-0 > div";
            public readonly static string modelSort = "#aeGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-2.tg-h-0 > div";
            public readonly static string classOOBPercentSort = "#aeGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-6.tg-h-0 > div";
            public readonly static string valueSort = "#aeGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-5.tg-h-0 > div > div";
            public readonly static string refreshButton = "#grid-refresh-aeGrid-action-bar-top > span";
            public readonly static string rewindButton = "#page-start-aeGrid-action-bar-top > svg";
            public readonly static string includeOpenProposals = ".mds-switch__text_trx";
            public readonly static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void GoTo()
        {
            Menu.GoTo(Menu.WorkflowSubMenu.MenuItems.analysis);
            WaitForPageToLoad();
        }

        public static void Filter(AnalysisPageFilter[] filters)
        {
            if (filters != null)
            {
                foreach (AnalysisPageFilter filter in filters)
                {
                    IWebElement filterElement = Test.driver.FindElement(By.CssSelector(filter.selector));
                    filterElement.SendKeys(filter.value);
                }
            }
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            Test.driver.FindElement(By.CssSelector(Selectors.analysisTable));
            Test.driver.FindElement(By.CssSelector(Selectors.rebalanceButton));
            Thread.Sleep(2000);
        }

        public static void Rebalance(string rebalanceButtonSelector)
        {
            Test.driver.FindElement(By.CssSelector(Selectors.includeOpenProposals)).Click();
            IWebElement buttonElement = Test.driver.FindElement(By.CssSelector(rebalanceButtonSelector));
            Thread.Sleep(5000);
            buttonElement.Click();
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new AnalysisPageData());
        }
    }
}
