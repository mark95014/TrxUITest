using TestContext = NUnit.Framework.TestContext;
using OpenQA.Selenium;
using TrxUITest.src.pages;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests.utils
{
    public class MultiFlyerTradeProposal : MultiTradeProposal
    {
        public void ApplyLimitOrders(LimitOrder[] limitOrders) {
            int saveTestCaseId = Test.GetTestCaseId();
            TestContext.CurrentContext.Test.Arguments[0] = 5943480;

            foreach (LimitOrder limitOrder in limitOrders)
            {
                Console.WriteLine($"limit order:{limitOrder.duration} {limitOrder.price} {limitOrder.symbol}");
                IWebElement symbolColumnHeader = TrxUITest.src.utils.SeleniumHelpers.FindElement(FlyerPage.Selectors.symbolColumnHeader);
                //IWebElement symbolColumnHeader =  SeleniumHelpers.FindElement(FlyerPage.Selectors.symbolColumnHeader);
                symbolColumnHeader.SendKeys(limitOrder.symbol);

                IWebElement statusColumnHeader = src.utils.SeleniumHelpers.FindElement(FlyerPage.Selectors.statusColumnHeader);
                statusColumnHeader.Click();
                statusColumnHeader.Click(); //click twice to sort the Incompatibles to the bottom

                SeleniumHelpers.FindElement(FlyerPage.Selectors.firstLimitPrice).Click();

                SeleniumHelpers.WaitForElementToContain(FlyerPage.Selectors.limitOrderTitle, "Manage Fix Flyer Trades");
                SeleniumHelpers.WaitForElementToContain(FlyerPage.Selectors.limitOrderSymbol, limitOrder.symbol);

                SeleniumHelpers.FindElement(FlyerPage.Selectors.limitOrderDuration).SendKeys(limitOrder.duration);
                SeleniumHelpers.FindElement(FlyerPage.Selectors.limitOrderPrice).SendKeys(limitOrder.price);

                SeleniumHelpers.FindElement(FlyerPage.Selectors.limitOrderSaveButton).Click();
                Thread.Sleep(1000);

                FlyerPage.WaitForPageToLoad();

                SeleniumHelpers.ClearField(FlyerPage.Selectors.symbolColumnHeader);
            }

            Test.TestCaseFinish(); //Record result of the limit orders test case
            TestContext.CurrentContext.Test.Arguments[0] = saveTestCaseId; //Resume previous test case
        }

        public void SubmitTrades(LimitOrder[] limitOrders)
        {
            SeleniumHelpers.SelectOptionByText(TradeProposalsPage.Selectors.householdSelect, "Trades");
            Thread.Sleep(2000);
            SeleniumHelpers.WaitForElementToDisappear(TradeProposalsPage.Selectors.spinner);
            SeleniumHelpers.FindElement(TradeProposalsPage.Selectors.directTradesButton).Click();
            FlyerPage.WaitForPageToLoad();

            if (limitOrders != null) ApplyLimitOrders(limitOrders);
            FlyerPage.WaitForPageToLoad();
            SeleniumHelpers.FindElement(FlyerPage.Selectors.selectAllCheckbox).Click();
            SeleniumHelpers.FindElement(FlyerPage.Selectors.selectAllCheckbox).Click();
            SeleniumHelpers.FindElement(FlyerPage.Selectors.submitButton).Click();
            FlyerPage.WaitForPageToLoad();
            SeleniumHelpers.FindElement(FlyerPage.Selectors.accountColumnHeader).Click(); //insure order
            Thread.Sleep(10000);
            FlyerPage.VerifyPage();

            SeleniumHelpers.FindElement(FlyerPage.Selectors.viewHistoryButton).Click();
            FlyerHistoryPage.WaitForPageToLoad();
            FlyerHistoryPage.GetHistory();
            FlyerHistoryPage.VerifyPage();
            SeleniumHelpers.FindElement(FlyerHistoryPage.Selectors.exitButton).Click();
            FlyerPage.WaitForPageToLoad();
            TradeProposalsPage.GoTo();
        }

        public void ProcessTrades(LimitOrder[] limitOrders)
        {
            base.MoveProposals();
            SubmitTrades(limitOrders);
            base.Cleanup();
        }
    }
}