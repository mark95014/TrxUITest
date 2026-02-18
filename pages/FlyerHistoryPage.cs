using OpenQA.Selenium;
using System;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class FlyerHistoryPage
    {
        public static class Selectors
        {
            public static readonly string title = "#fix-flyer-view-history-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > h2 > span";
            public static readonly string tradeDate = "#trade-date";
            public static readonly string viewButton = "#get-fix-flyer-trade-history > span";
            public static readonly string exitButton = "#fix-flyer-view-history-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            public static readonly string spinner = "#fix-flyer-submit-process-spinner";
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(1000);
            SeleniumHelpers.WaitForElementToContain(FlyerHistoryPage.Selectors.title, "Fix Flyer View History");
        }

        public static void GetHistory()
        {
            string currentDate = DateTime.Now.ToString("MM/dd/yy");
            IWebElement tradeDateElement = SeleniumHelpers.FindElement(Selectors.tradeDate);
            tradeDateElement.Click();
            Thread.Sleep(5000);
            tradeDateElement.Click();
            Thread.Sleep(5000);
            tradeDateElement.SendKeys(currentDate.ToString());
            Thread.Sleep(5000);
            SeleniumHelpers.FindElement(Selectors.viewButton).Click();
        }

        public static void VerifyPage() 
        {
            CommonVerifyPage.Verify(new FlyerHistoryPageData());
        }
    }
}