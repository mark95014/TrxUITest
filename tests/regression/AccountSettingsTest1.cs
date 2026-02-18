using NUnit.Framework;
using TrxUITest.src.tests.regression;
using TrxUITest.src.utils;

namespace TrxUITest
{
    [TestFixture]

    class AccountSettingsTest1 : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            AccountSettingsTestBase.Init();
        }

        [TestCase(5075772)]
        public void TestCaseSMA(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsSMA);
        }

        [TestCase(5043887)]
        public void TestCaseChangeModel(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsChangeModel);
        }

        [TestCase(5058736)]
        public void TestCaseCantChangeModel(int testCaseId)
        {
            new AccountSettingsTestBase().ChangeModelFailTestCase(AccountSettingsTestBase.accountSettingsCantChangeModel);
        }
    }
}