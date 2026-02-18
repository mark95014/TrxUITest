using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.pages
{
    public class CashResultsPageData: PageData
    {
        public TextElement title = new TextElement("[id*='prop-results-modal-header']");
        public TextElement totalValue = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(1) > h4");
        public TextElement totalCash = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(2) > h4");
        public TextElement cashGoal = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(3) > h4");
        public TextElement cashNeedsMin = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(4) > h4");
        public TextElement cashNeedsMax = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(5) > h4");
        public TextElement symbol = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(1) > h4");
        public TextElement model = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(2) > h4");
        public TextElement target = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(3) > h4");
        public TextElement tolerance = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(4) > h4");
        public TextElement minimumSetAside = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(5) > h4");
        public TextElement maximumSetAside = new TextElement(" div > div > section > div.mds-section__content_trx > div > div:nth-child(3) > div:nth-child(6) > h4");
        public SimpleGridElement accountsGrid = new SimpleGridElement("#edit-prop-results-modal > div > div > section > div.mds-section__content_trx > div > div:nth-child(5) > div");
    }
}