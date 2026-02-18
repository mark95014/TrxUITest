using NUnit.Framework;
using TrxUITest.src.inputData;
using TrxUITest.src.pages;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class TacticalTraderTest4 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TradeProposalsPage.GoTo();
            TradeProposalsPage.CancelProposals();
        }

        [TestCase(4846419)]
        public void TestCase1(int testCaseId)
        {
            TacticalTestBase.UpdateClientSettings("8186", TacticalTestBase.clientSettingsLocked);
            TacticalTestBase.UpdateClientSettings("8187", TacticalTestBase.clientSettingsHidden);
            TacticalTestBase.TestCase(TacticalTradeInputData.trade10);
        }

        [TestCase(4847404)]
        public void TestCase2(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade11);
        }

        [TestCase(4848121)]
        public void TestCase3(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade12);
        }
    }
}