using NUnit.Framework;
using TrxUITest.src.inputData;
using TrxUITest.src.pages;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class TacticalTraderTest7 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TradeProposalsPage.GoTo();
            TradeProposalsPage.CancelProposals();
        }

        [TestCase(4852232)]
        public void TestCase1(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade19);
        }

        [TestCase(4852269)]
        public void TestCase2(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade20);
        }

        [TestCase(4868210)]
        public void TestCase3(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade21);
        }

        [TestCase(5248601)]
        public void TestCase4(int testCaseId)
        {
            TacticalTestBase.UpdateClientSettings("8187", TacticalTestBase.clientSettingsNoModel);
            TacticalTestBase.TestCase(TacticalTradeInputData.trade22);
        }
    }
}