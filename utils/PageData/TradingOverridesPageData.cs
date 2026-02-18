using TrxUITest.src.utils.PageData.Elements;

public class TradingOverridesPageData : PageData
{
    public TextElement title  = new TextElement("#override-trades-modal h2 > span");
    public SimpleGridElement grid = new SimpleGridElement("#override-trades-modal > div > div > section > div.mds-section__content_trx > form > div:nth-child(2) > div");
}