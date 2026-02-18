

using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class InactiveAccountsPage
    {
        public static class Selectors
        {
            public static readonly string accountNumberColumnHeader = "#inactiveAccountsGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div";
            public static readonly string exitButton = "#inactive-accounts-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
        }

        public static void WaitForPageToLoad()
        {
            InactiveAccountsPageData pageData = new InactiveAccountsPageData();
            SeleniumHelpers.FindElement(pageData.title.selector);
            SeleniumHelpers.FindElement(pageData.grid.selector);
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButton).Click();
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new InactiveAccountsPageData());
        }
    }
}