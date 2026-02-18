using System.Threading;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    class EditProposalPage
    {
        public static readonly string pageUrl = "app.aspx#/enterprise/trade-proposals";

        public static class Selectors
        {
            readonly public static string breadCrumbs = "#bread-crumb-title";
            readonly public static string saveProposalButton = "#edit-proposal-save-btn";
            readonly public static string resetButton = "#edit-proposal-reset-btn";
            readonly public static string cancelButton = "#edit-proposal-cancel-btn";
            readonly public static string confirmResetButton = "#edit-prop-confirm-reset-modal > div.mds-modal__wrapper > section > div > div > span > span:nth-child(2) > button";
            readonly public static string reconcileButton = "#edit-prop-reconcile-update-btn";
            readonly public static string confirmReconcileButton = "#edit-prop-reconcile-modal > div > div > section > div.mds-section__content_trx > div > div:nth-child(3) > div > div > span > div > button.mds-button_trx.mds-button--primary_trx.mds-button--small_trx > span";

            //reconcile accounts modal
            readonly public static string reconcileModalHeader = "#edit-prop-reconcile-modal-header";
            readonly public static string numAccountsNotReconciled = "#edit-prop-reconcile-modal > div > div > section > div.mds-section__content_trx > div > div:nth-child(1) > h4";
            readonly public static string reconcileAccountPulldown = "#edit-prop-reconcile-grid-filter-AccountNumber";
            readonly public static string reconcileViewButton = "#edit-prop-reconcile-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left button";
            readonly public static string reconcileAddToAccountCashButton = "#edit-prop-reconcile-addtocash-btn";

            readonly public static string selectAllCheckbox = ".tg-checkbox-all";
            readonly public static string sellAllButton = "#edit-prop-sellall-position-btn";
            readonly public static string confirmSellAllButton = "#edit-prop-sell-allpos-confirm-btn";
            readonly public static string cancelTradesButton = "#edit-prop-canceltrade-position-btn";
            readonly public static string confirmCancelTradesButton = "#edit-prop-cancel-trade-confirm-btn";

            readonly public static string expandSwitch = "#mds-content-page-wrapper > div.page-router-wrapper > div > div > div:nth-child(2) > div.col-sm-7 > div > section > div.row > div.col-sm-9 > span:nth-child(3) > div > label > span";
            readonly public static string editsSwitch = "#mds-content-page-wrapper > div.page-router-wrapper > div > div > div:nth-child(2) > div.col-sm-7 > div > section > div.row > div.col-sm-9 > span:nth-child(1) > div > label > span";
            readonly public static string tradesSwitch = "#mds-content-page-wrapper > div.page-router-wrapper > div > div > div:nth-child(2) > div.col-sm-7 > div > section > div.row > div.col-sm-9 > span:nth-child(2) > div > label > span";

            readonly public static string constraintsButton = "#edit-prop-constraints-btn";
            readonly public static string cashButton = "#edit-prop-cash-btn";
            readonly public static string notesButton = "#edit-prop-notes-btn";
            readonly public static string workflowButton = "#edit-prop-workflow-btn";

            readonly public static string accountsPulldown = "#edit-prop-fundsummary-grid-filter-Account";
            readonly public static string symbol = "#edit-prop-fundsummary-grid-filter-Symbol";
            readonly public static string firstCheckbox = "#edit-prop-fundsummary-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-0.tg-level-0.tg-cell-checkbox.tg-list-first > div";
            readonly public static string firstFilteredAccount = "#edit-prop-fundsummary-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-1.tg-level-0.tg-align-left > span";
            readonly public static string firstAccount = "#edit-prop-fundsummary-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div.tg-scrollview > div > div.tg-row.tg-level-0.tg-even.tg-pane-first.tg-list-first > div.tg-cell.tg-c-1.tg-level-0.tg-align-left > span";
            readonly public static string editAmount = "#edit-prop-edit-cash-input";
            readonly public static string takeDiffButton = "#edit-prop-diff-position-btn";
            readonly public static string balanceButton = "#edit-prop-balance-position-btn";
            readonly public static string toggleSignButton = "#edit-prop-plusminus-position-btn";
            readonly public static string tradeLotsButton = "#edit-prop-tradelots-position-btn";
            readonly public static string undoEditsButton = "#edit-prop-undo-edits-btn";
            readonly public static string confirmUndoEditsButton = "#edit-prop-undo-edits-confirm-btn";
            readonly public static string saveEditButton = "#edit-prop-commit-changes-btn";

            readonly public static string classButton = "#class";
            readonly public static string subclassButton = "#subClass";

            //Unbalanced Accounts panel
            readonly public static string subclassPulldown = "#edit-prop-ubalance-subclass";
            readonly public static string symbolPulldown = "#edit-prop-ubalance-symbol";
            readonly public static string buyAmountInput = "(//*[@id='edit-prop-edit-cash-input'])[2]";
            readonly public static string balanceAccountButton = "#edit-prop-balance-accounts-btn";
            readonly public static string buySecurityButton = "#edit-prop-buy-sec-btn";
            readonly public static string unbalancedAccountsPulldown = "#edit-prop-uaccounts-grid-filter-AccountNumber";
            readonly public static string unbalancedAccountsFirstCheckbox = "#edit-prop-uaccounts-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-0.tg-level-0.tg-cell-checkbox.tg-list-first > div";
        
            readonly public static string tradeLotTitle = "#edit-prop-trade-lots-modal-header";
            readonly public static string tradeLotShares = "#edit-prop-trade-lots-grid-filter-Shares";
            readonly public static string tradeLotNumber = "#edit-prop-trade-lots-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-0.tg-level-0.tg-align-left.tg-list-first";
            readonly public static string tradeLotSellAmount = "#edit-prop-lot-trade-input";
            readonly public static string tradeLotSellButton = "#edit-prop-lots-balance-sell";
            readonly public static string tradeLotSellAllButton = "#edit-prop-lots-balance-sellall";
            readonly public static string tradeLotExitButton = "#edit-prop-trade-lots-modal button > span > svg";
            readonly public static string tradeLotLotNumber = "#edit-prop-trade-lots-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div > div > div > div.tg-cell.tg-c-0.tg-level-0.tg-align-left.tg-list-first";

            readonly public static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void VerifyToggles()
        {
            SeleniumHelpers.FindElement(Selectors.editsSwitch).Click();
            CommonVerifyPage.Verify(new EditProposalPageData());

            SeleniumHelpers.FindElement(Selectors.editsSwitch).Click();
            SeleniumHelpers.FindElement(Selectors.tradesSwitch).Click();
            CommonVerifyPage.Verify(new EditProposalPositionsPageData());
            SeleniumHelpers.FindElement(Selectors.tradesSwitch).Click();
            SeleniumHelpers.FindElement(Selectors.classButton).Click();
            CommonVerifyPage.Verify(new EditProposalSummaryPageData());
            SeleniumHelpers.FindElement(Selectors.subclassButton).Click();
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(5000);
            SeleniumHelpers.WaitForElementToContain(Selectors.breadCrumbs, "Edit Proposal");
            SeleniumHelpers.FindElement(Selectors.subclassButton);
            Thread.Sleep(1000);
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner, 900000);
        }

        public static void VerifySecurityDetail()
        {
            CommonVerifyPage.Verify(new EditProposalSecurityDetailPageData());
        }

        public static void VerifyPage()
        {
            EditProposalPage.WaitForPageToLoad();

            // var thumb = '#edit-prop-fundsummary-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div.tg-scrollbar.tg-scrollbar-v > div.tg-scrollbar-thumb'
            // var scrollbarTrack = '#edit-prop-fundsummary-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div.tg-scrollbar.tg-scrollbar-v > div.tg-scrollbar-track'

            CommonVerifyPage.Verify(new EditProposalPageData());
            // verifyToggles(this, browser)

            SeleniumHelpers.FindElement(Selectors.cashButton).Click();
            Thread.Sleep(1000);
            CashResultsPage.WaitForPageToLoad();
            CashResultsPage.VerifyPage();
            CashResultsPage.Exit();
            Thread.Sleep(1000);

            SeleniumHelpers.FindElement(Selectors.notesButton).Click();
            Thread.Sleep(1000);
            NotesPage.WaitForPageToLoad();
            NotesPage.VerifyPage(Note.NoteType.review);
            NotesPage.Exit();
            Thread.Sleep(1000);

            SeleniumHelpers.FindElement(Selectors.constraintsButton).Click();
            Thread.Sleep(1000);
            TradingConstraintsPage.WaitForPageToLoad();
            TradingConstraintsPage.VerifyPage();
            TradingConstraintsPage.Exit();
            Thread.Sleep(1000);

            SeleniumHelpers.FindElement(Selectors.workflowButton).Click();
            Thread.Sleep(1000);
            WorkflowHistoryPage.WaitForPageToLoad();
            WorkflowHistoryPage.VerifyPage();
            WorkflowHistoryPage.Exit();
            Thread.Sleep(1000);
        }

        public static void GoTo(string clientId)
        {
            SeleniumHelpers.FindElement(TradeProposalsPage.Selectors.householdSelect);
            var selectCommand = "$('#trade-prop-household-select option:contains(" + clientId + ")').prop({selected: true})";
            JavaScriptExec.Execute(selectCommand);
            Thread.Sleep(10000);
        }
    }
}
