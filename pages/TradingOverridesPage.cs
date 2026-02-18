using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class TradingOverridesPage
    {
        public static class Selectors
        {
            public static readonly string exitButton = "#override-trades-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            public static readonly string securityDescription = "#overrides-trade-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-1.tg-level-0.tg-align-left";
            public static readonly string securityLink = "#overrides-trade-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-1.tg-level-0.tg-align-left";
            public static readonly string symbolFilter = "#overrides-trade-grid-filter-Symbol";
            public static readonly string symbolHeader = "#overrides-trade-grid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div";
        }

        public static void WaitForPageToLoad()
        {
            TradingOverridesPageData pageData = new TradingOverridesPageData();
            SeleniumHelpers.FindElement(pageData.title.selector);
        }

        public static void FilterBySymbol(string symbol)
        {
            Thread.Sleep(1000);
            IWebElement symbolElement = SeleniumHelpers.FindElement(Selectors.symbolFilter);
            symbolElement.Clear();
            symbolElement.SendKeys(symbol);
        }

        public static void FilterByDescription(string description)
        {
            Thread.Sleep(1000);
            IWebElement symbolElement = SeleniumHelpers.FindElement(Selectors.securityDescription);
            symbolElement.Clear();
            symbolElement.SendKeys(description);
        }

        public static void VerifyPage()
        {
            SeleniumHelpers.FindElement(Selectors.symbolHeader).Click();
            CommonVerifyPage.Verify(new TradingOverridesPageData());
        }

        public static void Exit()
        {
            IWebElement exitButtonElement = SeleniumHelpers.FindElement(Selectors.exitButton);
            Thread.Sleep(500);
            exitButtonElement.Click();
        }
    }
}
