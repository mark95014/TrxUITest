using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class CustodianSettingsPage
    {
        public class Selectors
        {
            public static readonly string saveButton = "#custodians-save-btn";
            public static readonly string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static readonly string url = Test.webURL + "app.aspx#/enterprise/custodians";

        public static void Update(CustodianSettings custodianSettings)
        {
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            Thread.Sleep(5000);
            CustodianSettingsPageData data = new CustodianSettingsPageData();
            SeleniumHelpers.FindElement(data.name.selector).SendKeys(custodianSettings.name);

            if (custodianSettings.tradeFormat != null)
            {
                SeleniumHelpers.FindElement(data.name.selector).SendKeys(custodianSettings.name);
                SeleniumHelpers.FindElement(data.tradeFormat.selector).SendKeys(custodianSettings.tradeFormat);
            }

            if (custodianSettings.costApproach != null)
            {
                string interval = custodianSettings.costApproach.ToString();
                SeleniumHelpers.FindElement(data.costApproach.selector).SendKeys(interval);
            }

            if (custodianSettings.penaltyIntervalDays != null)
            {
                IWebElement element = SeleniumHelpers.FindElement(data.penaltyIntervalDays.selector);
                element.Clear();
                element.SendKeys(custodianSettings.penaltyIntervalDays.ToString());
            }

            if (custodianSettings.penaltyPercent != null)
            {
                IWebElement element = SeleniumHelpers.FindElement(data.penaltyPercent.selector);
                element.Clear();
                element.SendKeys(custodianSettings.penaltyPercent.ToString());
            }

            IWebElement saveButtonElement = SeleniumHelpers.FindElement(Selectors.saveButton);
            SeleniumHelpers.WaitForElementToBeVisible(Selectors.saveButton);
            saveButtonElement.Click();

            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            Thread.Sleep(5000);
        }

        public static void WaitForPageToLoad()
        {
            //This page initializes with partially filled data, then fills it in, thus wrecking the automation timing, so we must pause.
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            Thread.Sleep(2000);
            SeleniumHelpers.FindElement(new CustodianSettingsPageData().title.selector);
            SeleniumHelpers.FindElement(Selectors.saveButton);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new CustodianSettingsPageData());
        }
    }
}