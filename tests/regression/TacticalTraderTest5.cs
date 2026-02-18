using NUnit.Framework;
using TrxUITest.src.inputData;
using TrxUITest.src.pages;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class TacticalTraderTest5 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TradeProposalsPage.GoTo();
            TradeProposalsPage.CancelProposals();
        }

        [TestCase(4848582)]
        public void TestCase1(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade13);
        }

        [TestCase(4848581)]
        public void TestCase2(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade14);
        }

        [TestCase(4851539)]
        public void TestCase3(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade15);
        }
    }
}