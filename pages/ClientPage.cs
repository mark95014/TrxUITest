using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class ClientPage
    {
        public static class Selectors
        {
            readonly public static string spinner = "#edge > div > div > div.loader-overlay > div > div";
            //                                       #edge > div > div > div.loader-overlay > div > div > div.mds-loader__item_trx.mds-loader__item--8_trx
            readonly public static string breadCrumbs = "#bread-crumb-title";
            readonly public static string reviewAvailable = "#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(1) > form > div:nth-child(1) > table > tbody > tr:nth-child(4) > td:nth-child(1)";
            readonly public static string reviewButton = "#view-review";
            readonly public static string viewErrorsButton = "#view-errors";
            readonly public static string viewPositionsButton = "#view-positions";
            readonly public static string viewOverridesButton = "#view-overrides";
            readonly public static string viewAccountsButton = "#view-accounts";
            readonly public static string manageSettingsButton = "#household-detail-manage-settings-btn";
            readonly public static string tradesPulldown = "#trade-select";
            readonly public static string tradeButton = "#trade-btn";
            readonly public static string rebalanceButton = "#view-oob";
            readonly public static string tlhRebalanceButton = "#view-tlh";
            readonly public static string cashRebalanceButton = "#view-model-cash";
            readonly public static string carryForwardLossLongTerm = "#caploss-lterm";
        }

        public static void GoTo(string client)
        {
            ClientsPage.GoTo();
            Thread.Sleep(5000);

            if (int.TryParse(client, out int n)) ClientsPage.FilterById(client);
            else ClientsPage.FilterByName(client);

            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(ClientsPage.Selectors.firstClient).Click();

            WaitForPageToLoad();
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.WaitForElementToContain(Selectors.breadCrumbs, "Client Details >");
            SeleniumHelpers.FindElement(Selectors.carryForwardLossLongTerm);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new ClientPageData());

            IWebElement viewErrorsButtonElement = SeleniumHelpers.FindElement(Selectors.viewErrorsButton);
            Thread.Sleep(1000);
            viewErrorsButtonElement.Click();
            ErrorsPage.WaitForPageToLoad();
            ErrorsPage.VerifyPage();
            ErrorsPage.Exit();

            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            IWebElement viewPositionsButtonElement = SeleniumHelpers.FindElement(Selectors.viewPositionsButton);
            Thread.Sleep(1000);
            viewPositionsButtonElement.Click();
            ClientPositionsPage.WaitForPageToLoad();
            ClientPositionsPage.VerifyPage();
            ClientPositionsPage.Exit();

            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            IWebElement viewOverridesButtonElement = SeleniumHelpers.FindElement(Selectors.viewOverridesButton);
            Thread.Sleep(1000);
            viewOverridesButtonElement.Click();
            TradingOverridesPage.WaitForPageToLoad();
            TradingOverridesPage.VerifyPage();
            TradingOverridesPage.Exit();

            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            IWebElement viewAccountsButtonElement = SeleniumHelpers.FindElement(Selectors.viewAccountsButton);
            Thread.Sleep(1000);
            viewAccountsButtonElement.Click(); //browser.jsClick(this.elements['viewAccountsButton'].selector)
            AccountsPage.WaitForPageToLoad();
            AccountsPage.VerifyPage();
            AccountsPage.Exit();
        }
    }
}