using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class TacticalBlotterPage
    {
        public static class Selectors
        {
            public static readonly string openPositionsButton = "#position-pill-btn";
            public static readonly string blotterButton = "#blotter-pill-btn";
            public static readonly string refreshButton = "#grid-refresh-proposed-blotter-grid-action-bar-top";
            public static readonly string deleteSelectionsButton = "#delete-proposals-btn";
            public static readonly string createProposalsButton = "#create-proposals-btn";
            public static readonly string spinner = "#edge > div > div > div.loader-overlay > div > div";
            public static readonly string messageFilter = "#proposed-blotter-grid-filter-Message";
            //???firstMessageColumn = "#proposed-blotter-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div.tg-row.tg-level-0.tg-even.tg-pane-first.tg-list-first > div.tg-cell.tg-c-12.tg-level-0.tg-align-left > span"
            public static readonly string firstMessageColumn = "#proposed-blotter-grid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div > div";
            public static readonly string totalRecords = "#proposed-blotter-grid-action-bar-top-totalrecords";
        }

        public static void WaitForPageToLoad()
        {
            TacticalBlotterPageData pageData = new TacticalBlotterPageData();

            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            string titleSelector = pageData.title.selector;
            SeleniumHelpers.WaitForElementToContain(titleSelector, "Tactical Trader");
        }

        public static void VerifyPage()
        {
            TacticalBlotterPageData pageData = new TacticalBlotterPageData();
            SeleniumHelpers.FindElement(pageData.title.selector);
            CommonVerifyPage.Verify(new TacticalBlotterPageData());
        }
    }
}