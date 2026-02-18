using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest
{
    public class TacticalTradePageData: PageData
    {
        public TextElement title = new TextElement("#tactical-trader-detail-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > h2 > span");
        public SimpleGridElement buyGrid = new SimpleGridElement("#tactical-trade-grid-wrapper");
    }
}