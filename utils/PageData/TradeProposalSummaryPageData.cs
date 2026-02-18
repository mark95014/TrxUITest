using TrxUITest.src.utils.PageData.Elements;

public class TradeProposalSummaryPageData : PageData
{
    public TextElement title = new TextElement("#trade-prop-summary-modal-header");
    public TextElement ytdGains = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(1) > span");
    public TextElement maxGainsAllowed = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(2) > span");
    public TextElement maxGainsTaxAllowed = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(3) > span");
    public TextElement rebalanceTotal = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(4) > span");
    public TextElement shortTermGains = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(5) > span");
    public TextElement longTermGains = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(6) > span");
    public TextElement totalGains = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(7) > span");
    public TextElement carryForwardLoss = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(8) > span");
    public TextElement transactionCosts = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(9) > span");
    public TextElement redemptionFees = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(10) > span");
    public TextElement taxLotIdentifications = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(11) > span");
    public TextElement locOptSavings = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(12) > span");
    public TextElement tlhTaxSavings = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(13) > span");
    public TextElement cgdaSavings = new TextElement("#trade-prop-summary-modal div.col-sm-5 > div:nth-child(14) > span");
}