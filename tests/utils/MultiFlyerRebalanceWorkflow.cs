using OpenQA.Selenium;
using System;
using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests.utils
{
    public class MultiFlyerRebalanceWorkflow : MultiRebalanceWorkflow
    {
        public void Rebalance(string rebalanceButtonSelector,
                                MultiAnalysisRebalancePageBase multiRebalancePage,
                                AnalysisPageFilter[] filters = null,
                                ProposalEditsClass[] proposalEdits = null,
                                LimitOrder[] limitOrders = null)
        {
            base.CreateProposals(rebalanceButtonSelector, multiRebalancePage, filters);
            MultiFlyerTradeProposal proposals = new MultiFlyerTradeProposal();
            proposals.WaitForTradeProposals();

            if (proposalEdits != null)
            {
                foreach (var edit in proposalEdits)
                {
                    Console.WriteLine($"edit: {edit.clientId} {edit.edits}");

                    SeleniumHelpers.SelectOptionByValue(TradeProposalsPage.Selectors.householdSelect, edit.clientId);
                    Thread.Sleep(2000);
                    SeleniumHelpers.WaitForElementToDisappear(TradeProposalsPage.Selectors.spinner, 300);
                    IWebElement button = SeleniumHelpers.FindElement(TradeProposalsPage.Selectors.editProposalButton);
                    Thread.Sleep(1000);
                    button.Click();
                    EditProposalPage.WaitForPageToLoad();
                    edit.Process(false);
                    TradeProposalsPage.WaitForPageToLoad();
                }

                proposals.ProcessTrades(limitOrders);
            }
        }
    }
}