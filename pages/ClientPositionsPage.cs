using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class ClientPositionsPage
    {
        public static class Selectors
        {
            public readonly static string exitButton = "#positions-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            public readonly static string symbolHeader = "#positions-grid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-1.tg-h-0 > div > div.tg-column-name";
        }

        public static void WaitForPageToLoad()
        {
            ClientPositionsPageData data = new ClientPositionsPageData();
            SeleniumHelpers.FindElement(data.title.selector);
        }

        public static void VerifyPage()
        {
            SeleniumHelpers.FindElement(Selectors.symbolHeader).Click(); //sort to work around TRX giving random order
            CommonVerifyPage.Verify(new ClientPositionsPageData());
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButton).Click();
        }
    }
}