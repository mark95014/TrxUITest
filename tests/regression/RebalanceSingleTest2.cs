using NUnit.Framework;
using TrxUITest.src.tests;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class RebalanceSingleTest2 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RebalanceSingleTestBase.Init();
        }

        [TestCase(1677130)]
        public void TestCase8186(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8186");
        }

        [TestCase(1677137)]
        public void TestCaseAlreadyInBalance(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8212", false, null, null, null, false);
        }

        [TestCase(1677135)]
        public void TestCaseSwitchModel(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8186", false, RebalanceSingleTestBase.clientSettings1);
        }
    }
}