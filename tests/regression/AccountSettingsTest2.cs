using NUnit.Framework;
using TrxUITest.src.pages;
using TrxUITest.src.tests.regression;
using TrxUITest.src.utils;

namespace TrxUITest
{
    [TestFixture]

    class AccountSettingsTest2 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            AccountSettingsTestBase.Init();
        }

        [TestCase(5069986)]
        public void TestCaseRestrictedAccount(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsRestrictedAccount);
        }

        [TestCase(5043888)]
        public void TestCaseTaxable(int testCaseId)
        {
            new AccountSettingsTestBase().VerifyAccountTestCase(AccountSettingsTestBase.accountSettingsTaxable);
        }

        [TestCase(5043889)]
        public void TestCaseIRA(int testCaseId)
        {
            new AccountSettingsTestBase().VerifyAccountTestCase(AccountSettingsTestBase.accountSettingsIRA);
        }
    }
}