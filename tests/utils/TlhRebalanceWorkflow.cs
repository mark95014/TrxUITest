using System;
using System.Collections.Generic;
using System.Text;
using TrxUITest.src.pages;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests.utils
{
    public class TlhRebalanceWorkflow : RebalanceWorkflow
    {
        public TlhRebalanceWorkflow(string clientId) : base (clientId, false)
        { 
        }

        public override bool Oob(ClientPageData data) {
            return data.tlhOpportunities.data.ToString().Contains("red"); //??? does this work
        }

        public bool HasReview(ClientPageData data) {
            return Oob(data);
        }

        public override void ChildExecute() {
            SeleniumHelpers.FindElement(ClientPage.Selectors.tlhRebalanceButton).Click();
        }

        //const page = browser.page.tlhCompliancePage() as TlhCompliancePage
        //page.waitForPageToLoad().verifyPage(browser)
        //const createProposalButtonSelector = new tlhCompliancePageData().createProposalButton.selector
        //if (this.oob(clientData)) { browser.execute("document.querySelector('" + createProposalButtonSelector + "').click();")} 
        //else { browser.back()}
        public override void Compliance(ClientPageData data) {
            TlhCompliancePage.WaitForPageToLoad();
            TlhCompliancePage.VerifyPage();
            if (Oob(data))
            {
                SeleniumHelpers.FindElement(new TlhCompliancePageData().createProposalButton.selector).Click();
            }
            else 
            {
                Test.driver.Navigate().Back();
            }
        }
    }
}
