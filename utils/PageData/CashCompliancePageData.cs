using TrxUITest.src.utils.PageData.Elements;

public class CashCompliancePageData : PageData
{
    public TextElement title = new TextElement("#bread-crumb-title");
    public TextElement clientId = new TextElement("#household-number");
    public TextElement model = new TextElement("#model-desc");
    public TextElement subclass =  new TextElement("#subclass-desc");
    public TextElement totalCash = new TextElement("#cash-needs-amounts-wrapper > div:nth-child(1) > div > h4 > label > div");
    public TextElement cashVariance = new TextElement("#cash-needs-amounts-wrapper > div:nth-child(2) > div > h4 > label > div");
    public TextElement cashNeeds = new TextElement("#cash-needs-amounts-wrapper > div:nth-child(3) > div > h4 > label > div");
    public TextElement accountCashNeeds = new TextElement("#cash-needs-amounts-wrapper > div:nth-child(4) > div > h4 > label > div");
    public TextElement minimumCashNeeds = new TextElement("#cash-needs-amounts-wrapper > div:nth-child(5) > div > h4 > label > div");
    public TextElement maximumCashNeeds = new TextElement("#cash-needs-amounts-wrapper > div:nth-child(6) > div > h4 > label > div");
    public TextElement totalValue = new TextElement("#cash-needs-list-wrapper > div:nth-child(1) > div > h4 > label > div");
    public TextElement cashGoal = new TextElement("#cash-needs-list-wrapper > div:nth-child(2) > div > h4 > label > div");
    public TextElement modelTarget = new TextElement("#cash-needs-list-wrapper > div:nth-child(3) > div > h4 > label > div");
    public TextElement tolerance = new TextElement("#cash-needs-list-wrapper > div:nth-child(4) > div > h4 > label > div");
    public TextElement minimumSetAside = new TextElement("#cash-needs-list-wrapper > div:nth-child(5) > div > h4 > label > div");
    public TextElement maximumSetAside = new TextElement("#cash-needs-list-wrapper > div:nth-child(6) > div > h4 > label > div");
    public ElementAttribute createProposalButton = new ElementAttribute("#cash-needs-proposal-btn", "disabled");
    public SimpleGridElement accountsGrid = new SimpleGridElement("#cash-needs-accounts-grid-wrapper");
}