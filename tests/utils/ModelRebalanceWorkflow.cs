using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.tests.utils
{
    public class ModelRebalanceWorkflow : RebalanceWorkflow
    {
        readonly bool expectTrades;

        public ModelRebalanceWorkflow(string clientId, bool locationOptimization, bool expectTrades = true) : base(clientId, locationOptimization)
        {
            this.expectTrades = expectTrades;
        }

        public override bool Oob(ClientPageData data)
        {
            return data.OOB.data.ToString().Contains("red"); //??? does this work I think you need to call Get
        }

        public override void Compliance(ClientPageData data)
        {
            ModelCompliancePage.WaitForPageToLoad();
            ModelCompliancePage.VerifyPage();
            SeleniumHelpers.FindElement("#rebalance-btn").Click();
            //JavaScriptExec.Click("#rebalance-btn"); ???
        }

        public void VerifyNoTrades()
        {
            Thread.Sleep(1000);
            string noTradesModalSelector = "#trade-prop-error-modal";
            string noTradesMessageSelector = "#trade-prop-error-modal > div > div > section > div.mds-section__content_trx > div > div.mds-alert__body_trx > div > p";
            string exitButton = "#trade-prop-error-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            SeleniumHelpers.FindElement(noTradesModalSelector, 600000);
            string message = SeleniumHelpers.FindElement(noTradesMessageSelector).Text;
            string expectedMessage = "There are no trades to generate for this Review.";
            if (!message.Equals(expectedMessage))
            {
                Result result = new TextElement(noTradesMessageSelector).Verify("No Trades message", expectedMessage);
                Test.results.Add(result);
            }

            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(exitButton).Click();
        }

        public override void ChildExecute()
        {

            string rebalanceButtonSelector = ClientPage.Selectors.rebalanceButton;
            SeleniumHelpers.FindElement(rebalanceButtonSelector).Click();
            //If the statement above doesn't work try executing this:
            ////var clickCommand = "$('" + rebalanceButtonSelector + "').click()"
            //browser.execute(clickCommand)
        }

        public override void ReviewAndTrade(ClientPageData clientPageData) //Can I change RebalanceWorkflow.RewviewAndTrade to handle both versions???
        {
            WaitForReview();
            Review(clientPageData.clientId.data.ToString());

            if (Oob(clientPageData) && expectTrades)
            {
                GetTrades();
                TradeFiles();
                CancelProposal();
            }
            else
            {
                VerifyNoTrades();
            }
        }
    }
}