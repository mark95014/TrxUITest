using NUnit.Framework;
using TrxUITest.src.tests.regression;
using TrxUITest.src.utils;

namespace TrxUITest
{
    [TestFixture]

    class AccountSettingsTest3 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            AccountSettingsTestBase.Init();
        }

        [TestCase(5043891)]
        [Order(1)]
        public void TestCaseBillingAccount(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsBillingAccount);
        }

        [TestCase(5043893)]
        [Order(2)]
        public void TestCaseUnmanaged(int testCaseId)
        {
            new AccountSettingsTestBase().UnmanageTestCase(AccountSettingsTestBase.accountSettingsUnmanaged);
        }

        [TestCase(5043894)]
        [Order(3)]
        public void TestCaseMarginAccount(int testCaseId)
        {
            new AccountSettingsTestBase().MarginAccountTestCase(AccountSettingsTestBase.accountSettingsMarginAccount);
        }
    }
}