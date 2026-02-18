using OpenQA.Selenium;
using System.Collections.ObjectModel;
using TrxUITest.src.pages;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests.utils
{
    public class MultiTradeProposal
    {
        public void MoveProposals()
        {
            TradeProposalsPage.SetMoveType("All");
            TradeProposalsPage.MoveProposalTo("LVL1Review");

            UpdateWorkflowPage.WaitForPageToLoad();
            UpdateWorkflowPage.UpdateAndExit();
            
            TradeProposalsPage.SetMoveType("All");
            TradeProposalsPage.MoveProposalTo("Trades");

            UpdateWorkflowPage.WaitForPageToLoad();
            UpdateWorkflowPage.UpdateAndExit();
        }

        public void VerifyTrades()
        {
            ReadOnlyCollection<IWebElement> elements = SeleniumHelpers.FindElements(TradeProposalsPage.Selectors.tradeFilesButton, 1800);
            if (elements.Count > 0)
            {
                TradeProposalsPage.GetTrades();
                TradeProposalsPage.TradeFiles();
            }
        }

        public void Cleanup()
        {
            TradeProposalsPage.CancelProposals();
        }

        public void WaitForTradeProposals()
        {
            HomePage.GoTo();
            HomePage.WaitForTradeProposals();
            TradeProposalsPage.GoTo();
        }

        public void ProcessTrades()
        {
            WaitForTradeProposals();
            MoveProposals();
            VerifyTrades();
            Cleanup();
        }
    }
}
