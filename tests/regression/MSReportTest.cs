using NUnit.Framework;
using TrxUITest.src.utils;
using TrxUITest.src.pages;
using System.Threading;

namespace TrxUITest
{
    [TestFixture]
    class MSReportTest : BaseTest
    {
        readonly static string quickTake = ".quick-take";

        [OneTimeSetUp]
        public override void BaseSetup()
        {
            string errorMessage = "This test can only be run in the UAT or PROD environments.";
            Assume.That(Test.environment.ToUpper().Contains("UAT") || Test.environment.ToUpper().Contains("PROD"), errorMessage);
            Test.Startup(GetType().Name);
        }

        private void ExecuteTestCase(string symbol, string description)
        {
            SecuritiesPage.GoTo();
            SecuritiesPage.FilterBySymbol(symbol);
            SecuritiesPage.FilterByDescription(description);
            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(quickTake).Click();

            MSReportPage.WaitForPageToLoad();
            CommonVerifyPage.Verify(MSReportPage.data);

            Test.driver.Close(); //close report tab
            string parentWindow = Test.driver.WindowHandles[0];
            Test.driver.SwitchTo().Window(parentWindow); //focus on parent tab
            Thread.Sleep(5000);
        }

        [TestCase(1677150, "X", "UNITED STATES STEEL CORP")]
        [TestCase(1677151, "AA", "ALCOA INC COM")]
        [TestCase(1677152, "BPSIX", "Robeco Small Cap Value II Inst")]
        [TestCase(1677153, "VFINX", "Vanguard 500 Index Fund")]
        [TestCase(1677155, "SAIC", "Science Applications International Corp")]
        public void TestCase(int testCaseId, string symbol, string description)
        {
            ExecuteTestCase(symbol, description);
        }
    }
}