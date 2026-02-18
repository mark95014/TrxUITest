using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.pages
{
    public class EditProposalSecurityDetailPageData : PageData
    {
        public TextElement security = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(1) > div > h5");
        public TextElement accountDescription = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(2) > div > h5");
        public TextElement sellFlag = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(1) > h5");
        public TextElement buyFlag = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(3) > h5");
        public TextElement editedAmount = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(5) > h5");

        public TextElement securityUnrealizedShortTermGains = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2) > div");
        public TextElement securityUnrealizedLongTermGains = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(4) > table > tbody > tr:nth-child(1) > td.mds-data-table__cell.false.mds-data-table__cell--right > div");
        public TextElement securityProposedShortTermGains = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(4) > table > tbody > tr:nth-child(2) > td:nth-child(2) > div");
        public TextElement securityProposedLongTermGains = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(4) > table > tbody > tr:nth-child(2) > td.mds-data-table__cell.false.mds-data-table__cell--right > div");
        public TextElement securityEditedShortTermGains = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(4) > table > tbody > tr:nth-child(3) > td:nth-child(2) > div");
        public TextElement securityEditedLongTermGains = new TextElement("#edit-prop-position-details > div.mds-section__content_trx > div > div:nth-child(4) > table > tbody > tr:nth-child(3) > td.mds-data-table__cell.false.mds-data-table__cell--right > div");

        public TextElement securityProposedRealizedShortTermGains = new TextElement("#edit-prop-details > div.mds-section__content_trx > table > tbody > tr:nth-child(1) > td:nth-child(2) > div");
        public TextElement securityProposedRealizedLongTermGains = new TextElement("#edit-prop-details > div.mds-section__content_trx > table > tbody > tr:nth-child(1) > td.mds-data-table__cell.false.mds-data-table__cell--right > div");
        public TextElement securityProposedEditedRealizedShortTermGains = new TextElement("#edit-prop-details > div.mds-section__content_trx > table > tbody > tr:nth-child(2) > td:nth-child(2) > div");
        public TextElement securityProposedEditedRealizedLongTermGains = new TextElement("#edit-prop-details > div.mds-section__content_trx > table > tbody > tr:nth-child(2) > td.mds-data-table__cell.false.mds-data-table__cell--right > div");
    }
}