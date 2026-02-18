using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData;

namespace TrxUITest.src.tests.utils
{
    public class MultiRebalanceWorkflow
    {
        public void CreateProposals(string rebalanceButtonSelector, MultiAnalysisRebalancePageBase multiRebalancePage, AnalysisPageFilter[] filters = null)
        {
            AnalysisPage.GoTo();
            AnalysisPage.Filter(filters);
            AnalysisPage.Rebalance(rebalanceButtonSelector);
            multiRebalancePage.WaitForPageToLoad();
            multiRebalancePage.CreateProposal();
            multiRebalancePage.WaitForProcessingModal();
            multiRebalancePage.Exit();
            AnalysisPage.WaitForPageToLoad();
        }

        private void WaitForProposals()
        {
            HomePage.GoTo();
            HomePage.WaitForTradeProposals();
        }

        private void ProcessTrades()
        {
            new MultiTradeProposal().ProcessTrades();
        }

        public void Rebalance(string rebalanceButton, MultiAnalysisRebalancePageBase multiRebalancePage, AnalysisPageFilter[] filters = null)
        {
            CreateProposals(rebalanceButton, multiRebalancePage, filters);
            WaitForProposals();
            TradeProposalsPage.GoTo();
            ProcessTrades();
        }
    }
}