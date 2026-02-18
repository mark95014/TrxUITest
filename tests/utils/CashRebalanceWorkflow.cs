using System;
using System.Collections.Generic;
using System.Text;
using TrxUITest.src.pages;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests.utils
{
    public class CashRebalanceWorkflow : RebalanceWorkflow
    {
        public CashRebalanceWorkflow(string clientId) : base (clientId, false)
        { 
        }

        public override bool Oob(ClientPageData data) {
            return data.OOB.data.ToString().Contains("red"); //?? does this work
        }

        public bool HasReview(ClientPageData data) {
            return Oob(data);
        }

        public override void ChildExecute() {
            SeleniumHelpers.FindElement(ClientPage.Selectors.cashRebalanceButton).Click();
        }

        public override void Compliance(ClientPageData data) {
            CashCompliancePage.WaitForPageToLoad();
            CashCompliancePage.VerifyPage();
            if (Oob(data))
            {
                SeleniumHelpers.FindElement(new CashCompliancePageData().createProposalButton.selector).Click();
            }
            else 
            {
                Test.driver.Navigate().Back();
            }
        }
    }
}
