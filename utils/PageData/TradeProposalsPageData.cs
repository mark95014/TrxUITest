using TrxUITest.src.utils.PageData.Elements;

public class TradeProposalsPageData : PageData
{
    public TextElement title = new TextElement("#bread-crumb-title");
    public SelectOptionElement clientNameAndWorkflow = new SelectOptionElement("#trade-prop-household-select");
    public SimpleGridElement grid = new SimpleGridElement("#vue-route > div > div > div:nth-child(3) > div > section > div:nth-child(2)");
    public TextElement value = new TextElement("#trade-prop-details-wrapper > div:nth-child(1) > h4");
    public TextElement model = new TextElement("#trade-prop-details-wrapper > div:nth-child(2) > h4");
    public CurrentTimestampElement processedTimestamp = new CurrentTimestampElement("#trade-prop-details-wrapper > div:nth-child(3) > h4");
    public TextElement allowShortTermGains = new TextElement("#trade-prop-details-wrapper > div:nth-child(4) > h4");
    public TextElement allowWashSales = new TextElement("#trade-prop-details-wrapper > div:nth-child(5) > h4");
    public TextElement notes = new TextElement("#notes");
}