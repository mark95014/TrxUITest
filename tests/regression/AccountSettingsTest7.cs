using NUnit.Framework;
using TrxUITest.src.tests.regression;
using TrxUITest.src.utils;

namespace TrxUITest
{
    [TestFixture]

    class AccountSettingsTest7 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            AccountSettingsTestBase.Init();
        }
  
        [TestCase(5111026)]
        [Order(1)]
        public void TestCaseMFRounding1000(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsMutualFundRounding1000);
        }

        [TestCase(5043896)]
        [Order(2)]
        public void TestCaseTransactionCostsIncluded(int testCaseId)
        {
            new AccountSettingsTestBase().TransactionCostsTestCase(AccountSettingsTestBase.accountSettingsTransactionCostsIncluded);
        }

        [TestCase(5043897)]
        [Order(3)]
        public void TestCaseTransactionCostsAdded(int testCaseId)
        {
            new AccountSettingsTestBase().TransactionCostsTestCase(AccountSettingsTestBase.accountSettingsTransactionCostsAdded);
        }
    }
}