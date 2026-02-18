using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class AccountsPage
    {
        public static class Selectors
        {
            readonly public static string accountsGrid = "#accountsGrid";
            readonly public static string accountNumberFilter = "#accountsGrid-filter-AcctNum";
            readonly public static string firstAccount = "#accountsGrid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-0.tg-level-0.tg-align-left.tg-list-first";
            readonly public static string refreshButton = "#grid-refresh-accountsGrid-action-bar-top > span";
            readonly public static string accountDescription = "#accountsGrid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-4.tg-level-0.tg-align-left";
            readonly public static string spinner = "#edge > div > div > div.loader-overlay > div > div";
            readonly public static string inactiveAccountsButton = "#vue-route > div.container > div > div > button:nth-child(2) > span";
            readonly public static string pageUrl = "app.aspx#/accounts";
            readonly public static string accountNumberHeader = "#accountsGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-1.tg-h-0 > div > div";
        }

        public static void FilterByAccountNumber(string accountNumber)
        {
            Test.driver.FindElement(By.CssSelector(Selectors.refreshButton)).Click();
            IWebElement filterElement = Test.driver.FindElement(By.CssSelector(Selectors.accountNumberFilter));
            filterElement.SendKeys(accountNumber);
            Thread.Sleep(2000);
        }
    
        public static void WaitForPageToLoad()
        {
            AccountsPageData accountsPageData = new AccountsPageData();
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            Test.driver.FindElement(By.CssSelector(accountsPageData.title.selector));
        }

        public static void VerifyPage()
        {
            Test.driver.FindElement(By.CssSelector(Selectors.accountNumberHeader)).Click(); //sort
            CommonVerifyPage.Verify(new AccountsPageData());
        }

        public static void Exit()
        {
            Test.driver.Navigate().Back();
        }

        public static void GoTo()
        {
            Menu.GoTo(Menu.ClientManagementSubMenu.MenuItems.accounts);
            WaitForPageToLoad();
        }
    }
}
