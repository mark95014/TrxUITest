using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.pages
{
    public class EditProposalPageData: PageData
    {
        public TextElement title = new TextElement("#bread-crumb-title");
        public TextElement totalValue = new TextElement("#edit-prop-position-maint > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--level-5_trx > div > span:nth-child(4)");
        public TextElement totalCash = new TextElement("#edit-prop-position-maint > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--level-5_trx > div > span:nth-child(6)");

        //positionsGrid: SimpleGridElement = new SimpleGridElement("#mds-content-page-wrapper > div.page-router-wrapper > div > div > div:nth-child(2) > div.col-sm-7 > div > section > div:nth-child(2) > div > div.container.grid-container.grid-table-wrapper.container-stretch > div")
        public SimpleGridElement positionsGrid = new SimpleGridElement("#edit-prop-fundsummary-grid");
        // editCashInput: public  TextElement = new TextElement("#edit-prop-edit-cash-input") ???
        // balanceButton: public  TextElement = new TextElement("#edit-prop-balance-position-btn")
        // takeDiffButton: public  TextElement = new TextElement("#edit-prop-diff-position-btn")

        public TextElement totalProposedRealizedShortTermGains = new TextElement("#edit-prop-details > div.mds-section__content_trx > table > tbody > tr:nth-child(1) > td:nth-child(2) > div");
        public TextElement totalProposedRealizedLongTermGains = new TextElement("#edit-prop-details > div.mds-section__content_trx > table > tbody > tr:nth-child(1) > td.mds-data-table__cell.false.mds-data-table__cell--right > div");
        public TextElement totalEditedRealizedShortTermGains = new TextElement("#edit-prop-details > div.mds-section__content_trx > table > tbody > tr:nth-child(2) > td:nth-child(2) > div");
        public TextElement totalEditedRealizedLongTermGains = new TextElement("#edit-prop-details > div.mds-section__content_trx > table > tbody > tr:nth-child(2) > td.mds-data-table__cell.false.mds-data-table__cell--right > div");

        public TextElement model = new TextElement("#edit-prop-position-summary > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--level-5_trx > div > span");


        public SimpleGridElement summaryGrid = new SimpleGridElement("#edit-prop-summary-grid");
        public SimpleGridElement unbalancedAccountsGrid = new SimpleGridElement("#edit-prop-uaccounts-grid");
    }
}