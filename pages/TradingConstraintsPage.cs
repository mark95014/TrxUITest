using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class TradingConstraintsPage
    {
        public static class Selectors
        {
            readonly public static string exitButton = " div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg > path";
        }

        public static void WaitForPageToLoad()
        {
            TradingConstraintsPageData pageData = new TradingConstraintsPageData();
            SeleniumHelpers.FindElement(pageData.title.selector);
            SeleniumHelpers.WaitForElementToContain(pageData.title.selector, "Trading Constraints");
            SeleniumHelpers.FindElement(pageData.grid.selector);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new TradingConstraintsPageData());
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButton).Click();
        }
    }
}