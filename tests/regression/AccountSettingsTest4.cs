using NUnit.Framework;
using TrxUITest.src.tests.regression;
using TrxUITest.src.utils;

namespace TrxUITest
{
    [TestFixture]

    class AccountSettingsTest4 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            AccountSettingsTestBase.Init();
        }

        [TestCase(5100211)]
        [Order(1)]
        public void TestCaseNotMargin(int testCaseId)
        {
            new AccountSettingsTestBase().MarginAccountTestCase(AccountSettingsTestBase.accountSettingsNotMarginAccount);
        }

        [TestCase(5043895)]
        [Order(2)]
        public void TestCaseMarginPercent(int testCaseId)
        {
            new AccountSettingsTestBase().VerifyAccountTestCase(AccountSettingsTestBase.accountSettingsMarginPercent);
        }

        [TestCase(5043898)]
        [Order(3)]
        public void TestCaseMasterAccount(int testCaseId)
        {
            new AccountSettingsTestBase().VerifyAccountTestCase(AccountSettingsTestBase.accountSettingsMasterAccount);
        }
    }
}