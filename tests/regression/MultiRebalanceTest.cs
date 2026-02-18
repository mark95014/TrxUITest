using NUnit.Framework;
using System;
using System.IO;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest

{
    [TestFixture]
    
    class MultiRebalanceTest
    {
        [TestCase(3226861, "default.bak")]
        //baril and rowling deferred until backups can be converted from SQL 2019 to 2016
        //[TestCase(3226862, "RebalanceAPI/baril.bak")]
        //[TestCase(3226863, "RebalanceAPI/rowling.bak")]
        
        public void TestCase(int testCaseId, string databaseBackupFileName)
        {
            Console.WriteLine("MultiRebalanceTest.TestCase()");
            string testName = GetType().Name + "." + Path.GetFileNameWithoutExtension(databaseBackupFileName);
            Test.Startup(testName, databaseBackupFileName); //Each test case has a different database, so run the Startup here.
            new MultiRebalanceWorkflow().Rebalance(AnalysisPage.Selectors.rebalanceButton, new MultiAnalysisRebalancePage());
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