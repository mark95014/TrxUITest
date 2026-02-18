using TrxUITest.src.utils.PageData.Elements;

public class AccountPageData : PageData
{
    public TextElement title = new TextElement("#bread-crumb-title");
    public ValueElement accountNumber = new ValueElement("#account-select");
    public TextElement notes = new TextElement("#notes");
    public TextElement totalCash = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(1) > div:nth-child(1) > span");
    public TextElement totalValue = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(1) > div:nth-child(2) > span");
    public TextElement managedCash = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(3) > div:nth-child(1) > span");
    public TextElement investWithdraw = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(3) > div:nth-child(3) > span");
    public TextElement minimumTransaction = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(3) > div:nth-child(4) > span");
    public TextElement priceDate = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(3) > div:nth-child(5) > span");
    public TextElement lastTransactionDate = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(3) > div:nth-child(6) > span");
    public TextElement clientId = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(5) > div:nth-child(1) > span");
    public TextElement custodian = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(5) > div:nth-child(2) > span");
    public TextElement accountType = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(5) > div:nth-child(3) > span");
    public TextElement sweepAccount = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(5) > div:nth-child(4) > span");
    public TextElement taxable = new TextElement("#account-detail-summary > div.mds-section__content_trx > div:nth-child(5) > div:nth-child(5) > span");
    public ValueElement model = new ValueElement("#model-select");
    public ValueElement category = new ValueElement("#category-select");
    public CheckboxElement billingAccount = new CheckboxElement("#billingaccount-check");
    public CheckboxElement managedAccount = new CheckboxElement("#managedaccount-check");
    public CheckboxElement marginAccount = new CheckboxElement("#marginaccount-check");
    public ValueElement marginPercent = new ValueElement("#marginpct-input");
    public ValueElement dividendReinvestment = new ValueElement("#divreinvest-select");
    public ValueElement buyTransactionCosts = new ValueElement("#buytransactioncosts-select");
    public ValueElement sellTransactionCosts = new ValueElement("#selltransactioncosts-select");
    public TextElement masterAccount = new TextElement("#masteraccount-input");
    public CheckboxElement restrictedAccount = new CheckboxElement("#account-settings > div.mds-section__content_trx > div > div:nth-child(1) > div:nth-child(11) > div > div > label > span > span.mds-form__checkbox-visual");
    public CheckboxElement smaAccount = new CheckboxElement("#account-settings > div.mds-section__content_trx > div > div:nth-child(1) > div.row > div > div > label > span > span.mds-form__checkbox-visual");
    public ValueElement minimumCash = new ValueElement("#minimumcash-input");
    public ValueElement maximumCash = new ValueElement("#maximumcash-input");
    public ValueElement cashType = new ValueElement("#cashtype-select");
    public ValueElement cashGoal = new ValueElement("#cashgoal-select");
    public ValueElement minimumTransactionDollars = new ValueElement("#mintransactiondollar-input");
    public ValueElement minimumTransactionPercent = new ValueElement("#mintransactionpercent-input");
    public ValueElement minimumTransactionFlag = new ValueElement("#minimumtransactionflag-select");
    public ValueElement mutualFundRounding = new ValueElement("#mutualfundrounding-select");
    public ValueElement rmdMinimum = new ValueElement("#rmdminimum-input");
    public ValueElement rmdMaximum = new ValueElement("#rmdmaximum-input");
    public TextElement cashSetasideMinimum = new TextElement("#rmdminimum-input");
    public TextElement cashSetasideMaximum = new TextElement("#rmdmaximum-input");
    public ValueElement otherMinimum = new ValueElement("#otherminimum-input");
    public ValueElement otherMaximum = new ValueElement("#othermaximum-input");
    public ValueElement cashSetasideGoal = new ValueElement("#setasidecashgoal-select");
}