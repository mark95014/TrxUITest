using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using TrxUITest.src.utils;
using System.IO;

namespace TrxUITest
{
    [TestFixture]
    class HomePageTest
    {
        //HomePageTest test cases are non-standard in that they do a database restore, login, test case, logout, and database cleanup for each test case.
        private void TestCase(string databaseBackupFileName)
        {
            CommonVerifyPage.Verify(new HomePageData());
        }

        [TestCase(5347196, "KerntkeOtto.bak")]
        [NUnit.Framework.Ignore("Not running this test case until UAT is available. Cannot restore DBs on PROD.")]
        public void HomePageTestCase2(int testCaseId, string databaseBackupFileName)
        {
            TestCase(databaseBackupFileName);
        }

        [TestCase(5314724, "default.bak")]
        public void HomePageTestCase(int testCaseId, string databaseBackupFileName)
        {
            TestCase(databaseBackupFileName);
        }

        [SetUp]
        public void TestCaseSetup()
        {
            string databaseBackupFileName = TestContext.CurrentContext.Test.Arguments[1].ToString();
            string testName = GetType().Name + "." + Path.GetFileNameWithoutExtension(databaseBackupFileName);
            Test.Startup(testName, databaseBackupFileName); //Each test case has a different database, so run the Startup here.
        }

        [TearDown]
        public void TestCaseTearDown()
        {
            Test.TestCaseFinish();
            Test.LogOut();
            Test.driver.Quit();
            if (TestContext.Parameters["environment"] != "prod")
            {
                Database.Cleanup(Test.dbServer, Test.guid);
            }
            ExpectedResults.Close(Test.generateExpectedResults);
        }
    }
}