using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests.utils
{
    public abstract class RebalanceWorkflow
    { //model, tlh, cash

        string clientId;
        bool locationOptimization;

        public RebalanceWorkflow(string clientId, bool locationOptimization)
        {
            this.clientId = clientId;
            this.locationOptimization = locationOptimization;
        }

        public abstract void ChildExecute();

        public abstract void Compliance(ClientPageData data);

        public abstract bool Oob(ClientPageData data);

        public void Execute()
        {
            GotoClient(clientId);
            var data = new ClientPageData();
            data.Get();
            ChildExecute();
            Compliance(data);
            ReviewAndTrade(data);
        }

        public void GotoClient(string clientId)
        {
            Thread.Sleep(1000);
            ClientPage.GoTo(clientId);
            ClientPage.WaitForPageToLoad();
        }

        public void WaitForReview()
        {
            SeleniumHelpers.FindElement(ClientPage.Selectors.reviewAvailable);
            IWebElement reviewButton = SeleniumHelpers.FindElement(ClientPage.Selectors.reviewButton);
            Thread.Sleep(5000);
            reviewButton.Click();
            //browser.execute("$('#view-review').click()") //workaround for element would not receive the click error ???
        }

        public void Review(string clientId) 
        {
            TradeProposalsPage.WaitForPageToLoad();
            SeleniumHelpers.SelectOptionByValue(TradeProposalsPage.Selectors.householdSelect, clientId);
            if (locationOptimization) TradeProposalsPage.ChooseLocationOptimization();
            TradeProposalsPage.VerifyPage();
            TradeProposalsPage.MoveProposalTo("LVL1Review");
            TradeProposalsPage.MoveProposalTo("Trades");
        }

        public void GetTrades()
        {
            TradeProposalsPage.GetTrades();
        }

        public void CancelProposal() 
        {
            TradeProposalsPage.MoveProposalTo("Dismiss");
            TradeProposalsPage.MoveProposalTo("Cancel");
        }

        public void TradeFiles() {
            TradeFilesPage.WaitForPageToLoad();
            TradeFilesPage.VerifyPage();
        }

        public virtual void ReviewAndTrade(ClientPageData clientPageData)
        {
            if (Oob(clientPageData))
            {
                WaitForReview();
                Review(clientPageData.clientId.data.ToString());
                GetTrades();
                TradeFiles();
                CancelProposal();
            }
        }
    }
}