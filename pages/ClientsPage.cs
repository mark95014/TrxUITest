using OpenQA.Selenium;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class ClientsPage
    {
        public static class Selectors
        {
            public readonly static string assignClientsButton = "#vue-route > div.container > div > div > button:nth-child(1) > span";
            public readonly static string clientDetailsTable = "#householdsGrid";
            public readonly static string firstClient = "#householdsGrid div.tg-row.tg-level-0.tg-even.tg-pane-first.tg-list-first";
            public readonly static string idFilter = "#householdsGrid-filter-Id";
            public readonly static string nameFilter = "#householdsGrid-filter-Description";
            public readonly static string idHeader = "#householdsGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div";
            public readonly static string refreshButton = "#grid-refresh-householdsGrid-action-bar-top > span";
            public readonly static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        
        public static void GoTo()
        {
            Menu.GoTo(Menu.ClientManagementSubMenu.MenuItems.clients);
            WaitForPageToLoad();
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.FindElement(Selectors.clientDetailsTable);
        }

        public static void VerifyPage()
        {
            //SeleniumHelpers.FindElement(data.title.selector); ???
            SeleniumHelpers.FindElement(Selectors.idHeader).Click(); //sort
            CommonVerifyPage.Verify(new ClientsPageData());
        }

        public static void FilterById(string id)
        {
            SeleniumHelpers.FindElement(Selectors.refreshButton).Click();
            IWebElement filter = SeleniumHelpers.FindElement(Selectors.idFilter);
            filter.Clear();
            filter.SendKeys(id);
        }

        public static void FilterByName(string name)
        {
            IWebElement filter = SeleniumHelpers.FindElement(Selectors.nameFilter);
            SeleniumHelpers.FindElement(Selectors.refreshButton).Click();
            filter.Clear();
            filter.SendKeys(name);
        }
    }
}