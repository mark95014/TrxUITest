using NUnit.Framework;
using TrxUITest.src.inputData;
using TrxUITest.src.pages;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class TacticalTraderTest3 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TradeProposalsPage.GoTo();
            TradeProposalsPage.CancelProposals();
        }

        [TestCase(4845354)]
        public void TestCase1(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade7);
        }

        [TestCase(4845990)]
        public void TestCase2(int testCaseId)
        {
            TacticalTestBase.TestCase(TacticalTradeInputData.trade8);
        }

        [TestCase(4846418)]
        public void TestCase3(int testCaseId)
        {
            SecuritySettingsPage.UpdateSecuritySettings(TacticalTestBase.securitySettingsDoNotSell);
            TacticalTestBase.TestCase(TacticalTradeInputData.trade9);
            SecuritySettingsPage.UpdateSecuritySettings(TacticalTestBase.securitySettingsOkToSell);
        }
    }
}