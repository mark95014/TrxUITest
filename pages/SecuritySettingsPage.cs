using TestContext = NUnit.Framework.TestContext;
using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.tests;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class SecuritySettingsPage
    {
        public static class Selectors
        {
            readonly public static string title = "#sec-detail-settings > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > h2";
            readonly public static string saveButton = "#sec-detail-save-btn";
            readonly public static string deleteButton = "#sec-detail-delete-security-btn";
            readonly public static string confirmDeleteButton = "#sec-details-confirmdelete-modal > div > div > section > div.mds-section__content_trx > span > div > button.mds-button_trx.mds-button--primary_trx.mds-button--small_trx > span";
            readonly public static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void GoTo(string symbol) 
        {
            SecuritiesPage.GoTo();
            Thread.Sleep(5000);
            SecuritiesPage.FilterBySymbol(symbol);
            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(SecuritiesPage.Selectors.firstSecurity).Click();
        }

        public static void Update(SecuritySettings settings)
        {
            Thread.Sleep(1000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);

            SecuritySettingsPageData pageData = new SecuritySettingsPageData();

            switch (settings.sellFlag)
            {
                case SellFlag.MustSell:

                    SeleniumHelpers.FindElement(pageData.mustSellButton.selector).Click();
                    break;

                case SellFlag.DoNotSell:
                    SeleniumHelpers.FindElement(pageData.doNotSellButton.selector).Click();
                    break;

                case SellFlag.OkToSell:
                    SeleniumHelpers.FindElement(pageData.okToSellButton.selector).Click();
                    break;

                case SellFlag.PrioritySell:
                    SeleniumHelpers.FindElement(pageData.prioritySellButton.selector).Click();
                    break;
            }

            if (settings.redemptionFeePenaltyInterval != null)
            {
                switch (settings.redemptionFeePenaltyInterval)
                {
                    case RedemptionFeePenaltyInterval.always:

                        SeleniumHelpers.FindElement(pageData.redemptionFeePenaltyAlways.selector).Click();


                        if (settings.redemptionFeePenaltyPercent != null)
                        {
                            IWebElement penaltyPercentElement = SeleniumHelpers.FindElement(pageData.redemptionFeePenaltyPercent.selector);
                                penaltyPercentElement.Clear();
                                penaltyPercentElement.SendKeys(settings.redemptionFeePenaltyPercent.ToString());
                        }
                        break;


                    case RedemptionFeePenaltyInterval.never:
                        SeleniumHelpers.FindElement(pageData.redemptionFeePenaltyNever.selector).Click();
                        break;

                    case RedemptionFeePenaltyInterval.interval:
                        SeleniumHelpers.FindElement(pageData.redemptionFeePenaltyInterval.selector).Click();

                        if (settings.redemptionFeePenaltyPercent != null)
                        {
                            IWebElement penaltyPercentElement = SeleniumHelpers.FindElement(pageData.redemptionFeePenaltyPercent.selector);
                            penaltyPercentElement.Clear();
                            penaltyPercentElement.SendKeys(settings.redemptionFeePenaltyPercent.ToString());
                        }

                        if (settings.redemptionFeePenaltyDays != null)
                        {
                            IWebElement penaltyDaysElement = SeleniumHelpers.FindElement(pageData.redemptionFeePenaltyDays.selector);
                            penaltyDaysElement.Clear();
                            penaltyDaysElement.SendKeys(settings.redemptionFeePenaltyDays.ToString());
                        }
                        break;
                }
            }

            IWebElement saveButtonElement = SeleniumHelpers.FindElement(Selectors.saveButton);
            //this.waitForElementVisible('@saveButton') ???
            Thread.Sleep(1000);
            saveButtonElement.Click();
            Thread.Sleep(1000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
        }

        public static void WaitForPageToLoad()
        {
            //This page initializes with partially filled data, then fills it in, thus wrecking the automation timing, so we must pause.
            Thread.Sleep(1000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.FindElement(Selectors.title);
            SeleniumHelpers.FindElement(Selectors.saveButton);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new SecuritySettingsPageData());
        }

        public static void UpdateSecuritySettings(SecuritySettings securitySettings)
        {
            Thread.Sleep(1000);
            SecuritySettingsPage.GoTo(securitySettings.symbol);
            SecuritySettingsPage.WaitForPageToLoad();
            SecuritySettingsPage.Update(securitySettings);
            Thread.Sleep(1000);
        }

        public static void Delete()
        {
            TestContext.Progress.WriteLine("deleting the security");
            IWebElement deleteButtonElement = SeleniumHelpers.FindElement(Selectors.deleteButton);
            Thread.Sleep(2000);
            deleteButtonElement.Click();
            Thread.Sleep(2000);
            SeleniumHelpers.FindElement(Selectors.confirmDeleteButton).Click();
        }
    }
}
