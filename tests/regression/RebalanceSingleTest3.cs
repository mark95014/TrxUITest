using NUnit.Framework;
using TrxUITest.src.tests;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class RebalanceSingleTest3 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RebalanceSingleTestBase.Init();
        }

        [TestCase(43863)]
        public void TestCaseMOM(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8202", false, RebalanceSingleTestBase.clientSettings4);
        }

        [TestCase(1677136)]
        public void TestCase8187(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8187");
        }

        [TestCase(725911)]
        public void TestCase8206(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8206");
        }
    }
}