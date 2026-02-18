using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest
{
    public static class TacticalTradePage
    {
        public static class Selectors
        {
            public readonly static string tradeType = "#tactical-trader-Trade-Type-select";
            public readonly static string amount = "#sell-tactical-trade-detail";
            public readonly static string addButton = "#add-edit-tactical-trade-btn > span";
            public readonly static string buyGrid = "#tactical-trade-grid-wrapper > div";
            public readonly static string buySubClass = "#tactical-trades-detail-subclass-select";
            public readonly static string buySymbol = "#tactical-trades-detail-security-select";
            public readonly static string buyPercent = "#buy-tactical-trade-detail";
            public readonly static string saveButton = "#save-tactical-trades-btn > span";
            public readonly static string cancelAddButton = "#cancel-add-tactical-trade";
            public readonly static string cancelTradeButton = "#cancel-tactical-trades-btn";
            public readonly static string exitButton = "#tactical-trader-detail-modal > div.mds-modal__wrapper > section > div > header > div > button > svg";
            public readonly static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public readonly static string title = "Manage Trade Detail";


        public static void CreateTrade(TacticalTrade trade)
        {
            WaitForPageToLoad();
            SeleniumHelpers.FindElement(Selectors.tradeType).SendKeys(trade.sell.tradeType.ToString());
            SeleniumHelpers.FindElement(Selectors.amount).Clear();
            SeleniumHelpers.FindElement(Selectors.amount).SendKeys(trade.sell.amount);

            foreach(Buy buy in trade.buys)
            {
                if (buy.subClass != null)
                {
                    //SeleniumHelpers.SelectOptionInModal(Selectors.buySubClass, buy.subClass);
                    //SeleniumHelpers.FindElement(Selectors.buySubClass);
                    //SeleniumHelpers.WaitForElementToBeVisible(Selectors.buySubClass);
                    //Test.driver.FindElement(By.CssSelector(Selectors.buySubClass)).Click();
                    //string optionStr = $"option[value='{buy.subClass}']";
                    //Test.driver.FindElement(By.CssSelector(optionStr)).Click();
                    //Test.driver.FindElement(By.CssSelector(optionStr)).SendKeys(Keys.Escape);

                    IWebElement el = SeleniumHelpers.FindElement(Selectors.buySubClass);
                    el.Click();
                    el.SendKeys(buy.subClass);
                    el.SendKeys(Keys.Escape);
                    Thread.Sleep(2000);

                    SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
                }

                if (buy.symbol != null)
                {
                    //SeleniumHelpers.SelectOptionInModal(Selectors.buySymbol, buy.symbol);
                    //SeleniumHelpers.FindElement(Selectors.buySymbol);
                    //SeleniumHelpers.WaitForElementToBeVisible(Selectors.buySymbol);
                    //Test.driver.FindElement(By.CssSelector(Selectors.buySymbol)).Click();
                    //string optionStr = $"option[value='{buy.symbol}']";
                    //Test.driver.FindElement(By.CssSelector(optionStr)).Click();
                    //Test.driver.FindElement(By.CssSelector(optionStr)).SendKeys(Keys.Escape);

                    //IWebElement el = SeleniumHelpers.FindElement(Selectors.buySymbol);
                    //el.Click();
                    //el.SendKeys(buy.symbol);
                    //el.SendKeys(Keys.Escape);

                    SeleniumHelpers.SelectOptionByValue(Selectors.buySymbol, buy.symbol);
                    Thread.Sleep(2000);
                }

                SeleniumHelpers.FindElement(Selectors.buyPercent).Clear();
                SeleniumHelpers.FindElement(Selectors.buyPercent).SendKeys(buy.percent);
                Thread.Sleep(1000);

                SeleniumHelpers.FindElement(Selectors.addButton).Click();
                Thread.Sleep(1000);
            }

            SeleniumHelpers.FindElement(Selectors.saveButton).Click();
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(2000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            string selector = new TacticalTradePageData().title.selector;
            SeleniumHelpers.FindElement(selector);
            SeleniumHelpers.WaitForElementToContain(selector, title);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new TacticalTradePageData());
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButton).Click();
        }
    }
}