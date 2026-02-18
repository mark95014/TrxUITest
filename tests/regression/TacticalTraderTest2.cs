using NUnit.Framework;
using TrxUITest.src.inputData;
using TrxUITest.src.pages;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class TacticalTraderTest2 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TradeProposalsPage.GoTo();
            TradeProposalsPage.CancelProposals();
        }

        [TestCase(4848123)]
        public void TestCase1(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade4);
        }

        [TestCase(4826305)]
        public void TestCase2(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade5);
        }

        [TestCase(4826307)]
        public void TestCase3(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade6);
        }
    }
}