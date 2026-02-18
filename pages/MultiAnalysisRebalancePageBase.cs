using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;

namespace TrxUITest.src.utils
{
    public abstract class MultiAnalysisRebalancePageBase
    {
        public static class Selectors
        {
            public static string exitButton = "[data-mds-icon-name=\"remove\"]";
            public static string createProposalButton = "#multi-rebal-create-proposal";
            public static string numberOfProposals = "#multi-rebal-selected > label";
            public static string spinner = "#rebal-process-spinner > div > div > div > div > div > div.mds-loader__item_trx.mds-loader__item--7_trx";
            public static string rebalanceSetFilter = "#aeGrid-filter-RebalanceSet";
            public static string modalHeader = "#multi-rebal-modal-header";
        }

        public abstract void WaitForPageToLoad();
        
        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new HomePageData());
        }

        public void CreateProposal()
        {
            TestContext.Progress.WriteLine("Begin CreateProposal()");
            Thread.Sleep(1000);
            //Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            IWebElement element = Test.driver.FindElement(By.CssSelector(Selectors.createProposalButton));
            //Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Test.defaultTimeoutInSeconds);
            element.Click();
            TestContext.Progress.WriteLine("End CreateProposal()");
        }

        public void WaitForProcessingModal()
        {
            TestContext.Progress.WriteLine("Begin WaitForProcessingModal()");
            Thread.Sleep(5000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner, 1800);
            TestContext.Progress.WriteLine("End WaitForProcessingModal()");
        }

        public void Exit()
        {
            IWebElement element = Test.driver.FindElement(By.CssSelector(Selectors.exitButton));
            Thread.Sleep(5000);//??? was 10000
            element.Click();
        }
    }
}