using NUnit.Framework;
using TrxUITest.src.tests;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class RebalanceSingleTest1 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RebalanceSingleTestBase.Init();
        }

        [TestCase(3670229)]
        public void TestCaseMinimum(int testCaseId)
        {
            new RebalanceSingleTestBase().CashTestCase("8194", false, null, null, RebalanceSingleTestBase.accountSettingsMinimum);
        }

        [TestCase(4926928)]
        public void TestCaseMidpoint(int testCaseId)
        {
            new RebalanceSingleTestBase().CashTestCase("8194", false, null, null, RebalanceSingleTestBase.accountSettingsMidpoint);
        }

        [TestCase(4926929)]
        public void TestCaseMaximum(int testCaseId)
        {
            new RebalanceSingleTestBase().CashTestCase("8205", false, null, null, RebalanceSingleTestBase.accountSettingsMaximum);
        }
    }
}