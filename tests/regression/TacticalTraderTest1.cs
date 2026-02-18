using NUnit.Framework;
using TrxUITest.src.inputData;
using TrxUITest.src.pages;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class TacticalTraderTest1 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TradeProposalsPage.GoTo();
            TradeProposalsPage.CancelProposals();
        }

        [TestCase(4826302)]
        public void TestCase1(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade1);
        }

        [TestCase(4826303)]
        public void TestCase2(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade2);
        }

        [TestCase(4826304)]
        public void TestCase3(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade3);
        }
    }
}