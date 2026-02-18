using TrxUITest.src.utils.PageData.Elements;

internal class CustodianSettingsPageData: PageData
{
    public TextElement title = new TextElement("#bread-crumb-title-enterprise");
    public ValueElement name = new ValueElement("#custodians-select");
    public ValueElement tradeFormat = new ValueElement("#custodians-trade-formats-select");
    public ValueElement costApproach = new ValueElement("#custodians-cost-approach-select");
    public ValueElement penaltyIntervalDays = new ValueElement("#custodians-penalty-interval-days-input");
    public ValueElement penaltyPercent = new ValueElement("#custodians-penalty-percent-input");
}