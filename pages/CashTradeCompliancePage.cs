using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class CashTradeCompliancePage
    {
        public static class Selectors
        {
            public static readonly string createProposalButton = "#fast-cash-create-proposal";
            public static readonly string cashAmount = "#cash-trade-amt";
            public static readonly string firstAccountCheckbox = "#fast-cash-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div.tg-row.tg-level-0.tg-even.tg-pane-first.tg-list-first > div.tg-cell.tg-c-0.tg-level-0.tg-cell-checkbox.tg-list-first > div";
            public static readonly string confirmationButton = "#confirm-fast-cash > span > div > button.mds-button_trx.mds-button--primary_trx.mds-button--small_trx";
            public static readonly string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void WaitForPageToLoad()
        {
            CashTradeCompliancePageData data = new CashTradeCompliancePageData();
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.WaitForElementToContain(data.title.selector, "Trades");
            Thread.Sleep(1000);
        }

        public static void VerifyPage() {
            CommonVerifyPage.Verify(new CashTradeCompliancePageData());
        }
    }
}