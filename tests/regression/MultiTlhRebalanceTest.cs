using NUnit.Framework;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest

{
    [TestFixture]

    class MultiTlhRebalanceTest
    {
        [TestCase(3226863)]
        public void TestCase(int testCaseId)
        {
            Test.Startup(GetType().Name);
            new MultiRebalanceWorkflow().Rebalance(AnalysisPage.Selectors.tlhRebalanceButton, new MultiAnalysisTlhRebalancePage());
        }

        [TearDown]
        public void TestCaseTearDown()
        {
            Test.TestCaseFinish();
            Test.LogOut();
            Test.driver.Close();
            Database.Cleanup(Test.dbServer, Test.guid);
            ExpectedResults.Close(Test.generateExpectedResults);
        }
    }
}
