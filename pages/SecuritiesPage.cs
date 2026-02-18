using OpenQA.Selenium;
using System;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class SecuritiesPage
    {
        public static class Selectors
        {
            readonly public static string symbolHeader = "#securitiesGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div";
            readonly public static string refreshButton = "#grid-refresh-securitiesGrid-action-bar-top > span";
            readonly public static string symbolFilter = "#securitiesGrid-filter-Symbol";
            readonly public static string firstSecurity = "#securitiesGrid div.tg-row.tg-level-0.tg-even.tg-pane-first.tg-list-first";
            readonly public static string securityDetailsLink = "#securitiesGrid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-1.tg-level-0.tg-align-left";
            readonly public static string descriptionFilter = "#securitiesGrid-filter-Description";
            readonly public static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void GoTo()
        {
            Menu.GoTo(Menu.ClientManagementSubMenu.MenuItems.securities);
            WaitForPageToLoad();
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.FindElement(Selectors.symbolFilter);
        }

        public static void FilterBySymbol(string symbol)
        {
            IWebElement symbolFilterElement = Test.driver.FindElement(By.CssSelector(Selectors.symbolFilter));
            symbolFilterElement.Clear();
            //driver.FindElement(By.CssSelector(refreshButton)).Click();
            symbolFilterElement.SendKeys(symbol);
        }

        public static void FilterByDescription(string description)
        {
            Thread.Sleep(1000);
            IWebElement filterElement = Test.driver.FindElement(By.CssSelector(Selectors.descriptionFilter));
            filterElement.Clear();
            filterElement.SendKeys(description);
        }

        public static void VerifyPage()
        {
            Test.driver.FindElement(By.CssSelector(Selectors.symbolHeader)).Click(); //sort
            CommonVerifyPage.Verify(new SecuritiesPageData());
        }
    }
}