using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TrxUITest.src.utils
{
    public static class Menu
    {
        public static string home = "#dashboard";

        public static class WorkflowSubMenu
        {
            public static string submenu = "#edge > div > div > div > nav > div.mds-navigation__panel-content_trx > section:nth-child(2) > ul > li > span > span.mds-navigation__group-header-text_trx";
            public static class MenuItems
            {
                public static string analysis = "#analysis";
                public static string tradeProposals = "#trade-proposals";
                public static string recalculate = "#showRecalcComponent";
                public static string import = "#import";
            }
        }

        public static class TradeManagementSubMenu
        {
            public static string submenu = "#edge > div > div > div > nav > div.mds-navigation__panel-content_trx > section:nth-child(3) > ul > li > span";
            public static class MenuItems
            {
                public static string replace = "#global-replace";
                public static string tacticalTrader = "#tactical-trader";
                public static string history = "#history";
                public static string cgda = "#cgda";
            }
        }

        public static class ClientManagementSubMenu
        {
            public static string submenu = "#edge > div > div > div > nav > div.mds-navigation__panel-content_trx > section:nth-child(4) > ul > li > span > span.mds-navigation__group-header-text_trx";
            public static class MenuItems
            {
                public static string clients = "#households";
                public static string accounts = "#accounts";
                public static string positions = "#positions";
                public static string securities = "#securities";
                public static string reports = "#reports";
            }
        }

        public static class InvestmentModelingSubMenu
        {
            public static string submenu = "#edge > div > div > div > nav > div.mds-navigation__panel-content_trx > section:nth-child(5) > ul > li > span > span.mds-navigation__group-header-text_trx";

            public static class MenuItems
            {
                public static string myModels = "#models";
                public static string buySets = "#buy-sets";
                public static string restrictedPlans = "#restricted-plans";
                public static string modelsOfModels = "#models-of-models";
                public static string subBlends = "#blend-sub-classes";
            }
        }

        public static class SettingsSubmenu
        {
            public static string submenu = "#edge > div > div > div > nav > div.mds-navigation__panel-content_trx > section:nth-child(6) > ul > li > span > span.mds-navigation__group-header-text_trx";

            public static class MenuItems
            {
                public static string globalSettings = "#global-settings";
                public static string enterprise = "#enterprise";
                public static string locationOptimization = "#loc-opt";
                public static string classifications = "#classifications";
                public static string dataMaintenance = "#data-maintenance";
            }
        }

        public static class HelpSubmenu
        {
            public static string submenu = "#help-menu-btn";

            public static class MenuItems
            {
                public static string contactSupport = "//div[@class='mds-list-group-item__upper_trx']/span[contains(text(), 'Contact Support')]";
                public static string trainingId = "//div[@class='mds-list-group-item__upper_trx']/span[contains(text(), 'Training/Resources')]";
                public static string feedback = "//div[@class='mds-list-group-item__upper_trx']/span[contains(text(), 'Give Feedback')]";
                public static string releaseNotes = "//div[@class='mds-list-group-item__upper_trx']/span[contains(text(), 'Release Notes')]";
            }
        }

        public static void ScrollTo(string link)
        {
            IWebElement element = SeleniumHelpers.FindElement(link, useXpath: link.Contains("//"));
            //((IJavaScriptExecutor)Test.driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions actions = new Actions(Test.driver);
            actions.MoveToElement(element).Perform();
            IJavaScriptExecutor js = Test.driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0, -30);"); //Bring the top of the element into view
        }

        public static void ScrollToTop()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Test.driver;
            js.ExecuteScript("window.scrollTo(0, 0);");
        }

        public static void ScrollToHome()
        {
            ScrollTo(home);
        }

        public static void GoTo(string link)
        {
            ScrollTo(link);
            SeleniumHelpers.FindElement(link, useXpath: link.Contains("//")).Click();
            ScrollToTop();
        }

        public static void ToggleSubMenus()
        {
            SeleniumHelpers.FindElement(WorkflowSubMenu.submenu).Click();
            SeleniumHelpers.FindElement(TradeManagementSubMenu.submenu).Click();
            SeleniumHelpers.FindElement(ClientManagementSubMenu.submenu).Click();
            SeleniumHelpers.FindElement(InvestmentModelingSubMenu.submenu).Click();
            SeleniumHelpers.FindElement(SettingsSubmenu.submenu).Click();
            SeleniumHelpers.FindElement(HelpSubmenu.submenu).Click();
        }

        public static void InitializeMenu()
        {
            //PinTheMainMenu();
            ToggleSubMenus();
            ToggleSubMenus();
            ScrollToHome();
        }
    }
}