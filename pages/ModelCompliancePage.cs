using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class ModelCompliancePage
    {
        public static class Selectors
        {
            public readonly static string breadCrumbs = "#bread-crumb-title";
            public readonly static string subclassButton = "#sub-class-btn";
            public readonly static string classButton = "#class-btn";
            public readonly static string bothButton = "#both-display-btn";
            public readonly static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(Selectors.breadCrumbs);
            SeleniumHelpers.WaitForElementToContain(Selectors.breadCrumbs, "Model Compliance >");
            Thread.Sleep(5000);
        }

        public static void VerifyPage()
        {
            IWebElement bothElement = SeleniumHelpers.FindElement(Selectors.bothButton);
            Thread.Sleep(2000);
            bothElement.Click();//may need jsexec ???

            IWebElement subclassElement = SeleniumHelpers.FindElement(Selectors.subclassButton);
            Thread.Sleep(2000);
            subclassElement.Click();
            CommonVerifyPage.Verify(new SubclassModelCompliancePageData());

            IWebElement classElement = SeleniumHelpers.FindElement(Selectors.classButton);
            Thread.Sleep(2000);
            classElement.Click();
            CommonVerifyPage.Verify(new ClassModelCompliancePageData());
        }
    }
}