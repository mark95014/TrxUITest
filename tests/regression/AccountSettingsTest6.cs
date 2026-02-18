using NUnit.Framework;
using TrxUITest.src.tests.regression;
using TrxUITest.src.utils;

namespace TrxUITest
{
    [TestFixture]

    class AccountSettingsTest6 :BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            AccountSettingsTestBase.Init();
        }
  
        [TestCase(5043933)]
        [Order(1)]
        public void TestCaseReduceTransactions(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsMinimumTrans5043933);
        }

        [TestCase(5043934)]
        [Order(2)]
        public void TestCaseNoTransactions(int testCaseId)
        {
            new AccountSettingsTestBase().TestCaseNoTrades(AccountSettingsTestBase.accountSettingsMinimumTrans5043934);
        }

        [TestCase(5043935)]
        [Order(3)]
        public void TestCaseMFRounding10(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsMutualFundRounding10);
        }
    }
}