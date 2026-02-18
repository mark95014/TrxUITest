using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests
{
    class CashTradeWorkflow : RebalanceWorkflow
    {
        public readonly string cashAmount;
        public readonly string tradeType;

        public CashTradeWorkflow(string clientId, string cashAmount, string tradeType): base(clientId, false) {
            this.cashAmount = cashAmount;
            this.tradeType = tradeType;
        }

        public override bool Oob(ClientPageData data) {
            return true;
        }

        public bool HasReview(ClientPageData data) {
            return true;
        }

        public override void ChildExecute() {
            IWebElement pulldownElement = SeleniumHelpers.FindElement(ClientPage.Selectors.tradesPulldown, 60000);
            Thread.Sleep(1000);
            pulldownElement.SendKeys(tradeType);
    
            IWebElement tradeButtonElement = SeleniumHelpers.FindElement(ClientPage.Selectors.tradeButton);
            Thread.Sleep(1000);
            tradeButtonElement.Click();    
        }

        public override void Compliance(ClientPageData data) {
            CashTradeCompliancePage.WaitForPageToLoad();
            CashTradeCompliancePage.VerifyPage();

            SeleniumHelpers.FindElement(cashAmount).SendKeys(cashAmount);
            SeleniumHelpers.FindElement(cashAmount).SendKeys(cashAmount);
            SeleniumHelpers.FindElement(CashTradeCompliancePage.Selectors.firstAccountCheckbox).Click(); //jsClick necessary???
            SeleniumHelpers.FindElement(CashTradeCompliancePage.Selectors.createProposalButton).Click(); //jsClick necessary???
            SeleniumHelpers.FindElement(CashTradeCompliancePage.Selectors.confirmationButton).Click(); //jsClick necessary???
        }
    }
}