using NUnit.Framework;
using Ignore = NUnit.Framework.IgnoreAttribute;
using TrxUITest.src.pages;
using TrxUITest.src.tests;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    public class RebalanceSingleTest5 : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            RebalanceSingleTestBase.Init();
        }

        [TestCase(3230441)]
        public void TestCaseEquivalency(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8193", false, RebalanceSingleTestBase.clientSettings5);
        }

        [TestCase(3226864)]
        public void TestCaseLocOpt(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8206", true);
        }

        [TestCase(3228738)]
        public void TestCaseMustSell(int testCaseId)
        {
            new RebalanceSingleTestBase().TestCase("8195", false, null, RebalanceSingleTestBase.securitySettings1);
        }

        [TestCase(3228748)]
        [NUnit.Framework.Ignore("WEALTH-13033 and WEALTH-10233 need to be fixed to run this test case")]
        public void TestCaseDoNotSell(int testCaseId)
        {
            new RebalanceSingleTestBase().OverrideTestCase(RebalanceSingleTestBase.doNotSellSettings);
        }
    }
}