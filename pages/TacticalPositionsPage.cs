using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest
{
    public static class TacticalPositionsPage
    {
        public static class Selectors
        {
            public readonly static string openPositionsButton = "#position-pill-btn";
            public readonly static string blotterButton = "#blotter-pill-btn";
            public readonly static string subClassPulldown = "#tactical-trader-subclass-select";
            public readonly static string symbolPulldown = "#tactical-trader-security-select";
            public readonly static string createTradeButton = "#create-trade-details-btn > span";
            public readonly static string firstPageButton = "#page-start-requested-positions-grid-action-bar-top > span > svg";
            public readonly static string pageCount = "#requested-positions-grid-action-bar-top-pagecount";
            public readonly static string refreshButton = "#grid-refresh-requested-positions-grid-action-bar-top > span";
            public readonly static string accountFilter = "#requested-positions-grid-filter-AccountNumber";
            public readonly static string firstRowCheckbox = "#requested-positions-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-0.tg-level-0.tg-cell-checkbox.tg-list-first > div";
            public readonly static string spinner = "#edge > div > div > div.loader-overlay > div > div";
            public readonly static string valueFilter = "#requested-positions-grid-filter-Value";
            public readonly static string advisorFilter = "#requested-positions-grid-filter-AdvisorSet";
            public readonly static string controlsContainer = "#mds-page-shell-content > main > div.page-router-wrapper > div > div.container.padding-none > div.row.text-center";
            public readonly static string selectedCount = "#held-positions-selected";
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(2000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.WaitForElementToContain(new TacticalPositionsPageData().title.selector, "Tactical Trader");
        }

        public static void VerifyPage()
        {
            WaitForPageToLoad();
            CommonVerifyPage.Verify(new TacticalPositionsPageData());
        }

        public static void GoTo()
        {
            Menu.GoTo(Menu.TradeManagementSubMenu.MenuItems.tacticalTrader);
            WaitForPageToLoad();
        }
    }
}