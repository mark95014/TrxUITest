using TestContext = NUnit.Framework.TestContext;
using OpenQA.Selenium;
using TrxUITest.src.utils;
using TrxUITest.utils;


public static class HomePage
{
	public static class Selectors
	{
		public static string recalculatingSelector = "#recalcContainer > span:nth-child(2) > div > div > div";
		public static string logo = "#edge > div > div > header > div:nth-child(1) > div > svg > g > circle";
        public static string versionSelector = "#release-notes-version";
		public static string releaseNotesModal = "#release-notes-modal";
		public static string releaseNotesModalExitButtonSelector = "#release-notes-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
		public static string loadingClientInfoSelector = "#clients-loader > div > div > div > div.mds-loader__item.mds-loader__item--5";
		public static string spinnerSelector = "#edge > div > div > div.loader-overlay > div > div";
    }

	private static readonly List<Task> progressIndicators = new List<Task>();

	public static void GoTo()
    {
		Menu.GoTo(Menu.home);
    }

	public static void VerifyPage()
	{
		CommonVerifyPage.Verify(new HomePageData());
	}

	public static void StartWaitsForProgressIndicators()
    {
        progressIndicators.Add(Task.Run(() => SeleniumHelpers.WaitForElementToDisappear(Selectors.spinnerSelector)));
        progressIndicators.Add(Task.Run(() => SeleniumHelpers.WaitForElementToDisappear(Selectors.recalculatingSelector)));
		progressIndicators.Add(Task.Run(() => SeleniumHelpers.WaitForElementToDisappear(Selectors.loadingClientInfoSelector, 300)));
	}

	public static void WaitForPageToLoad()
    {
		Thread.Sleep(5000);
        TestContext.Progress.WriteLine("Begin WaitForPageToLoad()");
        SeleniumHelpers.FindElement(Selectors.logo);

        StartWaitsForProgressIndicators();
        Task.WaitAll(progressIndicators.ToArray());
        Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(default); //WaitForElementToDisappear changes the timeout

		if (TestContext.Parameters["environment"] != "prod")
		{
            SeleniumHelpers.FindElement(Selectors.releaseNotesModal);
            IWebElement releaseNotesModalExitButton = SeleniumHelpers.FindElement(Selectors.releaseNotesModalExitButtonSelector);
            Thread.Sleep(3000);
            TestRail.UpdateTestRailRun(TestRail.MakeRunName(GetTrxVersion()));
            releaseNotesModalExitButton.Click();
        }

        HomePageData data = new HomePageData();
        SeleniumHelpers.FindElement(data.nonCriticalTRX.selector);
        SeleniumHelpers.FindElement(data.oob.selector);
    }

	public static void WaitForTradeProposals()
	{
        Thread.Sleep(10000);//??? why
        HomePageData data = new HomePageData();
		string processedSelector = data.processed.selector;
        Test.driver.FindElement(By.CssSelector(data.aum.selector));
        Test.driver.FindElement(By.CssSelector(data.criticalTotal.selector));
        Test.driver.FindElement(By.CssSelector(processedSelector));
		//Thread.Sleep(30000);//???
		data.Get();
		string numProposals = data.proposals.data.ToString().Split(' ')[1].Trim();
        TestContext.Progress.WriteLine($"Waiting for processed proposals to equal {numProposals}");
		SeleniumHelpers.WaitForElementToContain(processedSelector, numProposals);
        TestContext.Progress.WriteLine($"Done waiting for processed proposals to equal {numProposals}");

		Database.WaitForJobs(Test.dbServer);
        TestContext.Progress.WriteLine("Returned from WaitForJobs()");//???
		if (Test.delayRebalance) Thread.Sleep(60000);
	}

	private static string GetTrxVersion()
	{
		Thread.Sleep(3000);
		IWebElement versionElement = Test.driver.FindElement(By.CssSelector(Selectors.versionSelector));
		string version = versionElement.Text;
		version = version[16..];

		return version;
	}
}