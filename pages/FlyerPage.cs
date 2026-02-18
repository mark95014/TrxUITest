using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class FlyerPage
    {
        public static class Selectors
        {
            readonly public static string title = "#bread-crumb-title";
            readonly public static string selectAllCheckbox = "#fixSubmitGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div > div";
            readonly public static string statusColumnHeader = "#fixSubmitGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-1.tg-h-0 > div > div.tg-column-name";
            readonly public static string accountColumnHeader = "#fixSubmitGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-3.tg-h-0 > div > div";
            readonly public static string symbolColumnHeader = "#fixSubmitGrid-filter-Symbol";
            readonly public static string firstLimitPrice = "#fixSubmitGrid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div.tg-scrollview > div > div.tg-row.tg-level-0.tg-even.tg-pane-first.tg-list-first > div.tg-cell.tg-c-10.tg-level-0.tg-align-left";
            readonly public static string submitButton = "#direct-trades-fix-submit-btn";
            readonly public static string viewHistoryButton = "#direct-trades-fix-history-btn > span";
            readonly public static string exitButton = "#trade-prop-directtrades-modal > div.mds-modal__wrapper > section > div > header > div > button > svg";
            readonly public static string spinner = "#fix-flyer-submit-process-spinner";

            //Limit Order Modal
            readonly public static string limitOrderTitle = "#manage-fix-flyer-trades-modal-header";
            readonly public static string limitOrderSymbol = "#manage-fix-flyer-trades-modal > div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(2) > label";
            readonly public static string limitOrderDuration = "#limit-duration-select";
            readonly public static string limitOrderPrice = "#fix-flyer-trades-limit-price-input";
            readonly public static string limitOrderExitButton = "#manage-fix-flyer-trades-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            readonly public static string limitOrderSaveButton = "#save-loc-opt > span";
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(2000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.WaitForElementToContain(Selectors.title, "Direct Trades", 300);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new FlyerPageData());
        }
    }
}
