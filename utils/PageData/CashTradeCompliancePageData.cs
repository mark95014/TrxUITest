using TrxUITest.src.utils.PageData.Elements;

public class CashTradeCompliancePageData : PageData
{
    public TextElement title = new TextElement("#trades-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > h2 > span");
    public SimpleGridElement grid = new SimpleGridElement("#fast-cash-grid > div > div.tg-pane-bodyer > div.tg-scrollpane.tg-pane.tg-pane-top.tg-pane-left.tg-pane-top-left > div");
}