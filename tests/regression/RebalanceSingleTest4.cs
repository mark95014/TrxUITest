using NUnit.Framework;
using TrxUITest.src.tests;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class RebalanceSingleTest4 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RebalanceSingleTestBase.Init();
        }

        [TestCase(1677127)]
        public void TestCaseSwitchModel(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8195", false, RebalanceSingleTestBase.clientSettings2);
        }

        [TestCase(3235490)]
        public void TestCaseEquities(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8190");
        }

        [TestCase(3228737)]
        public void TestCaseSwitchBuySet(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8188", false, RebalanceSingleTestBase.clientSettings3);
        }
    }
}