using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class UpdateWorkflowPage
    {
        public static class Selectors
        {
            public readonly static string title = "#trade-prop-multiprop-modal-header";
            public readonly static string updateButton = "#multi-proposal-update-status > span";
            public readonly static string exitButton = "#trade-prop-multiprop-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            public readonly static string spinner = "#multi-proposal-process-spinner > div > div > div > div > div";
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner, 1800); //Longer timeout for large DBs
            Test.driver.FindElement(By.CssSelector(Selectors.title));
            Test.driver.FindElement(By.CssSelector(Selectors.updateButton));
            Test.driver.FindElement(By.CssSelector(Selectors.exitButton));
            Thread.Sleep(1000);
        }

        public static void UpdateAndExit()
        {
            SeleniumHelpers.FindElement(Selectors.updateButton).Click();
            Thread.Sleep(2000);
            WaitForPageToLoad();
            IWebElement button = SeleniumHelpers.FindElement(Selectors.exitButton);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            button.Click();
        }
    }
}