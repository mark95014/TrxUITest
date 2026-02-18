using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class TradeProposalsPage
    {
        public static class Selectors
        {
            public static readonly string breadCrumbs= "#bread-crumb-title";
            public static readonly string applyButton = "#trade-prop-applystatus-btn";
            public static readonly string editProposalButton = "#trade-prop-edit-btn";
            public static readonly string moveTypeSelect = "#trade-prop-move-type-select";
            public static readonly string workflowPulldown = "#trade-prop-workflow-type-select";
            public static readonly string tradeFilesButton = "#trade-prop-tradefiles-btn";
            public static readonly string directTradesButton = "#trade-prop-directtrades-btn";
            public static readonly string locationOptimizationModeButton = "#trade-prop-locopt-pill-btn";
            public static readonly string chooseLocationOptimization = "#trade-prop-choose-loc-opt-btn";
            public static readonly string viewSummaryButton = "#trade-prop-view-summary-btn";
            public static readonly string tradingConstraintsButton = "#trade-prop-constraints-summary-btn";
            public static readonly string householdSelect = "#trade-prop-household-select";
            public static readonly string recalculating = "#recalcContainer > span.mds-label-inline";
            public static readonly string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(5000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.recalculating, 900);
            Thread.Sleep(2000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner, 300);
            SeleniumHelpers.WaitForElementToContain(Selectors.breadCrumbs, "Trade Proposals");
            //new WebDriverWait(Test.driver, TimeSpan.FromMinutes(60)).Until(e => e.FindElement(By.CssSelector(breadCrumbs))).Text.Trim().Equals("Trade Proposals");
            //Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Test.driver.FindElement(By.CssSelector(Selectors.workflowPulldown));
            //Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Test.defaultTimeoutInSeconds);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new TradeProposalsPageData());

            IWebElement summaryButton = SeleniumHelpers.FindElement(Selectors.viewSummaryButton);
            Thread.Sleep(1000);
            summaryButton.Click();
            TradeProposalSummaryPage.WaitForPageToLoad();
            TradeProposalSummaryPage.VerifyPage();
            TradeProposalSummaryPage.Exit();
            Thread.Sleep(1000);

            IWebElement constraintsButton = SeleniumHelpers.FindElement(Selectors.tradingConstraintsButton);
            Thread.Sleep(1000);
            constraintsButton.Click();
            TradingConstraintsPage.WaitForPageToLoad();
            TradingConstraintsPage.VerifyPage();
            TradingConstraintsPage.Exit();
            Thread.Sleep(1000);
        }

        public static void ChooseLocationOptimization()
        {
            IWebElement button = SeleniumHelpers.FindElement(Selectors.locationOptimizationModeButton);
            Thread.Sleep(5000);
            button.Click();
            IWebElement checkBox = SeleniumHelpers.FindElement(Selectors.chooseLocationOptimization);
            Thread.Sleep(5000);
            checkBox.Click();
        }

        //???
        //    goto(browser: Trx, clientId: string) {
        //const page = browser.page.tradeProposalsPage() as TradeProposalsPage

        //const householdListSelector = page.elements['householdSelect'].selector
        //page.waitForElementPresent(householdListSelector)
        ////var selectCommand = "$('" + householdListSelector + " option:contains('" + clientId + "')').attr('selected', 'selected')"
        //var selectCommand = "$('#trade-prop-household-select option:contains(" + clientId + ")').prop({selected: true})"
        //// var selectCommand = "$('#trade-prop-household-select')"
        //// selectCommand += " option contains('8199')"
        //// selectCommand += ".attr('selected', 'selected')"
        //console.log('selectCommand', selectCommand)
        //browser.execute(selectCommand)
        //browser.pause(10000)
        //page.waitForElementNotPresent(page.elements['spinner'].selector)

        public static void GoTo()
        {
            Menu.GoTo(Menu.WorkflowSubMenu.MenuItems.tradeProposals);
            WaitForPageToLoad();
        }

        public static void SetMoveType(string moveType)
        {
            Test.driver.FindElement(By.CssSelector(Selectors.moveTypeSelect));
            IWebElement moveTypeElement = SeleniumHelpers.FindElement(Selectors.moveTypeSelect, 60);
            Thread.Sleep(1000);
            moveTypeElement.SendKeys(moveType);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            Test.driver.FindElement(By.CssSelector(Selectors.applyButton)).Click();
            Thread.Sleep(3000);
        }

        public static void MoveProposalTo(string stage)
        {
            SeleniumHelpers.FindElement(Selectors.workflowPulldown, 60).SendKeys(stage);
            Thread.Sleep(1000);
            Test.driver.FindElement(By.CssSelector(Selectors.applyButton)).Click();
            Thread.Sleep(3000);
        }

        public static void GetTrades() 
        {
            SeleniumHelpers.SelectOptionByText(Selectors.householdSelect, "Trades");
            IWebElement button = SeleniumHelpers.FindElement(Selectors.tradeFilesButton, 1800);
            Thread.Sleep(1000);
            button.Click();
        }

        public static void CancelProposal()
        {
            MoveProposalTo("Dismiss");
            MoveProposalTo("Cancel");
        }

        public static void CancelProposals()
        {
            SetMoveType("All");
            MoveProposalTo("Dismiss");
            UpdateWorkflowPage.WaitForPageToLoad();
            UpdateWorkflowPage.UpdateAndExit();

            SetMoveType("All");
            MoveProposalTo("Cancel");
            UpdateWorkflowPage.WaitForPageToLoad();
            UpdateWorkflowPage.UpdateAndExit();
        }

        public static void TradeFiles()
        {
            TradeFilesPage.WaitForPageToLoad();
            TradeFilesPage.VerifyPage();
        }
    }
}