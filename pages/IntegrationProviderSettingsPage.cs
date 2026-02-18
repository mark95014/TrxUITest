using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Threading;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class IntegrationProviderSettingsPage
    {
        private static IntegrationProviderSettingsPageData data = new IntegrationProviderSettingsPageData();

        public static class Selectors
        {
            readonly public static string title = "#bread-crumb-title-enterprise";
            readonly public static string saveButton = "#trading-options-save-creds-btn > span";
            readonly public static string editUserNamePasswordLink = "#fix-edit-creds-link > span";
            readonly public static string viewTermsOfUse = "#fix-terms-link > div";
            readonly public static string termsOfUseCheckbox = ".mds-form__checkbox-visual";
            readonly public static string validateCredsLink = "#fix-login-link > div";
            readonly public static string enterpriseSettingsMenuLink = "#mds-list-item-enterprise > a > span";
            readonly public static string enterprisePulldownMenuLink = "#enterprise-menu-trigger > span:nth-child(2)";
            readonly public static string tradingOptionsMenuLink = "#enterprise-menu > div > nav > ul > li:nth-child(5) > span > div > div.mds-list-group-item__main_trx > div > span";
        }

        public static void GoTo()
        {
            Menu.GoTo(Menu.SettingsSubmenu.MenuItems.enterprise);
            Menu.ScrollTo(Selectors.enterprisePulldownMenuLink);
            SeleniumHelpers.Hover(Selectors.enterprisePulldownMenuLink);
            SeleniumHelpers.Hover(Selectors.tradingOptionsMenuLink);
            SeleniumHelpers.FindElement(Selectors.tradingOptionsMenuLink).Click();
        }

        public static void Update(IntegrationProviderSettings integrationProviderSettings)
        {
            IntegrationProviderSettingsPageData pageData = new IntegrationProviderSettingsPageData();
            SeleniumHelpers.FindElement(pageData.providerSelect.selector);
            SeleniumHelpers.FindElement(pageData.providerSelect.selector).SendKeys(integrationProviderSettings.providerName);
            SeleniumHelpers.FindElement(pageData.userName.selector);
            SeleniumHelpers.FindElement(pageData.userName.selector).SendKeys(integrationProviderSettings.user);
            SeleniumHelpers.FindElement(pageData.password.selector);
            SeleniumHelpers.FindElement(pageData.password.selector).SendKeys(integrationProviderSettings.password);
            ReadOnlyCollection<IWebElement> elements = SeleniumHelpers.FindElements(Selectors.viewTermsOfUse);

            if (elements.Count > 0) //For some providers, there is no "terms of use" dialog
            {
                SeleniumHelpers.FindElement(Selectors.viewTermsOfUse).Click();
                Thread.Sleep(1000);
                ReadOnlyCollection<string> windowHandles = Test.driver.WindowHandles;
                Test.driver.SwitchTo().Window(windowHandles[1]).Close(); //close the terms of use tab
                Test.driver.SwitchTo().Window(windowHandles[0]);
                SeleniumHelpers.FindElement(Selectors.termsOfUseCheckbox).Click();
            }

            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(Selectors.saveButton).Click();
            SeleniumHelpers.WaitForElementToDisappear(Selectors.saveButton);
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(2000);
            SeleniumHelpers.FindElement(Selectors.title);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new IntegrationProviderSettingsPageData());
        }
    }
}
