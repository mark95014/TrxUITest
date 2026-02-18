using NUnit.Framework;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest

{
    [TestFixture]

    class MultiCashRebalanceTest : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            TradeProposalsPage.GoTo();
            TradeProposalsPage.CancelProposals();
        }

        [TestCase(3226862)]
        public void TestCase(int testCaseId)
        {
            AnalysisPageFilter[] filters = { new AnalysisPageFilter(AnalysisPage.Selectors.classOOBPercent, "10") };
            new MultiRebalanceWorkflow().Rebalance(AnalysisPage.Selectors.cashRebalanceButton, new MultiAnalysisCashRebalancePage(), filters);
        }
    }
}