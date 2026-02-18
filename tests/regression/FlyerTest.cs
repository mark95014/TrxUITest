using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TrxUITest.src.pages;
using TrxUITest.src.utils;


namespace TrxUITest

{
    [TestFixture]

    class FlyerTest : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            string testName = GetType().Name;

            if (Test.environment.ToLower().Equals("uat"))
            {
                TradeProposalsPage.GoTo();
                TradeProposalsPage.CancelProposals();
                FlyerTestBase.SetUpFlyerData();
            } else
            {
                string msg = $"{testName} cannot be run in the {Test.environment} environment. It can only be run in UAT, because it needs access to the UAT file share.";
                Assert.Ignore(msg);
            }
        }

        [TestCase(3224607)]
        public void TestCase(int testCaseId)
        {
            FlyerTestBase.TestCase();
        }
    }
}