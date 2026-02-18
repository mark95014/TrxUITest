using NUnit.Framework;
using TrxUITest.src.tests.regression;
using TrxUITest.src.utils;

namespace TrxUITest
{
    [TestFixture]

    class AccountSettingsTest5 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            AccountSettingsTestBase.Init();
        }

        [TestCase(5043930)]
        [Order(1)]
        public void TestCaseCashGoalGain(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsCashGoalGain);
        }

        [TestCase(5043931)]
        [Order(2)]
        public void TestCaseCashGoalReduce(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsCashGoalReduce);
        }

        [TestCase(5043932)]
        [Order(3)]
        public void TestCaseMasterAccount(int testCaseId)
        {
            new AccountSettingsTestBase().TestCase(AccountSettingsTestBase.accountSettingsMinimumTrans5043932);
        }
    }
}