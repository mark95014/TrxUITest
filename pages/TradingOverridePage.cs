using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class TradingOverridePage
    {
        private static TradingOverridePageData data = new TradingOverridePageData();

        public static class Selectors
        {
            public readonly static string sellSetting = "#override-sell-setting-select";
            public readonly static string buySetting = "#override-buy-setting-select";
            public readonly static string addOverrideButton = "#add-override-btn";
            public readonly static string exitButton = "#override-trades-modal button > span > svg > path";
            public readonly static string tableTitle = "#override-trades-modal > div > div > section > div.mds-section__content_trx > form > div:nth-child(2) > div:nth-child(3) > div.row > div.col-sm-2 > h4";
        }

        public static void WaitForPageToLoad()
        {
            TradingOverridePageData pageData = new TradingOverridePageData();
            SeleniumHelpers.FindElement(pageData.title.selector);
            SeleniumHelpers.FindElement(Selectors.sellSetting);
            SeleniumHelpers.FindElement(Selectors.tableTitle);
        }

        public static void VerifyPage()
        {
            TradingOverridePageData pageData = new TradingOverridePageData();
            SeleniumHelpers.FindElement(pageData.symbol.selector);
            CommonVerifyPage.Verify(new TradingOverridePageData());
        }

        public static void Exit()
        {
            IWebElement exitButtonElement = SeleniumHelpers.FindElement(Selectors.exitButton);
            Thread.Sleep(500);
            exitButtonElement.Click();
        }
    }
}