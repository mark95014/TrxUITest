using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.tests;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class ClientSettingsPage
    {
        public static class Selectors
        {
            readonly public static string saveButtonSelector = "#manage-hh-settings-modal > div > div > section > div.mds-section__content_trx > form > div:nth-child(3) > button > span";
            readonly public static string exitButtonSelector = "#manage-hh-settings-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            readonly public static string spinnerSelector = "#edge > div > div > div.loader-overlay > div > div";
            readonly public static string greenCheckmarkSelector = "#manage-hh-settings-modal > div > div > section > div.mds-section__content_trx > form > div:nth-child(3) > span > span > svg";
        }

        public static void Update(ClientSettings clientSettings)
        {
            Thread.Sleep(1000);

            //Expand this to include all settings
            ClientSettingsPageData data = new ClientSettingsPageData();
            if (clientSettings.model != null) SeleniumHelpers.FindElement(data.model.selector).SendKeys(clientSettings.model);
            if (clientSettings.advisorSet != null) SeleniumHelpers.FindElement(data.advisor.selector).SendKeys(clientSettings.advisorSet);
            if (clientSettings.preferredBuySet != null) SeleniumHelpers.FindElement(data.buySet.selector).SendKeys(clientSettings.preferredBuySet);
            if (clientSettings.rebalanceSet != null) SeleniumHelpers.FindElement(data.rebalanceSet.selector).SendKeys(clientSettings.rebalanceSet);
            if (clientSettings.status != null) SeleniumHelpers.FindElement(data.status.selector).SendKeys(clientSettings.status);

            IWebElement saveButtonElement = SeleniumHelpers.FindElement(Selectors.saveButtonSelector);
            Thread.Sleep(1000);
            saveButtonElement.Click();
            //this.waitForElementVisible('@saveButton') ???
            Thread.Sleep(1000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinnerSelector);
            SeleniumHelpers.FindElement(Selectors.greenCheckmarkSelector, 300);
            Thread.Sleep(1000);
            IWebElement exitButtonElement = SeleniumHelpers.FindElement(Selectors.exitButtonSelector);
            Thread.Sleep(1000);
            exitButtonElement.Click();
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(1000);
            ClientSettingsPageData data = new ClientSettingsPageData();
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinnerSelector);
            SeleniumHelpers.FindElement(data.title.selector);
            SeleniumHelpers.FindElement(data.advisor.selector);
            SeleniumHelpers.FindElement(data.rebalanceSet.selector);
            SeleniumHelpers.FindElement(data.buySet.selector);
            SeleniumHelpers.FindElement(data.model.selector);
            SeleniumHelpers.FindElement(data.status.selector);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new ClientSettingsPageData());
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButtonSelector).Click();
        }

        public static void UpdateClientSettings(string clientId, ClientSettings clientSettings)
        {
            Thread.Sleep(1000);
            ClientPage.GoTo(clientId);
            ClientPageData data = new ClientPageData();
            data.Get();
            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(ClientPage.Selectors.manageSettingsButton).Click();
            //    clientPage.waitForElementVisible('@manageSettingsButton', 60000) ???

            ClientSettingsPage.WaitForPageToLoad();
            ClientSettingsPage.Update(clientSettings);
            Thread.Sleep(1000);
        }
    }
 }
