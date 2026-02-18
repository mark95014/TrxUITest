using TrxUITest.src.utils.PageData.Elements;

public class ClientPageData : PageData
{
    public TextElement breadCrumbs = new TextElement("#bread-crumb-title");
    public TextElement clientId = new TextElement("#household-number");
    public TextElement model = new TextElement("#model-desc");
    public TextElement notes = new TextElement("#notes");
    public ElementAttribute OOB = new ElementAttribute("#vue-route > div > div.container.main-container > div > div:nth-child(1) > form > div:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(1) > div > span", "className");
    public ElementAttribute cashNeeds = new ElementAttribute("#vue-route > div > div.container.main-container > div > div:nth-child(1) > form > div:nth-child(1) > table > tbody > tr:nth-child(2) > td:nth-child(1) > div > span", "className");
    public ElementAttribute tlhOpportunities = new ElementAttribute("#vue-route > div > div.container.main-container > div > div:nth-child(1) > form > div:nth-child(1) > table > tbody > tr:nth-child(3) > td:nth-child(1) > div > span", "className");
    public TextElement value = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(1) > form > div:nth-child(2) > table > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement classOOBPercentage = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(1) > form > div:nth-child(2) > table > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div > span.negative-ticker");
    public TextElement classOOBDollars = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(1) > form > div:nth-child(2) > table > tbody > tr:nth-child(3) > td.mds-td_trx.mds-td--right_trx > div > span.negative-ticker");
    public TextElement subClassOOBPercentage = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(1) > form > div:nth-child(2) > table > tbody > tr:nth-child(4) > td.mds-td_trx.mds-td--right_trx > div > span.negative-ticker");
    public TextElement subClassOOBDollars = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(1) > form > div:nth-child(2) > table > tbody > tr:nth-child(5) > td.mds-td_trx.mds-td--right_trx > div > span.negative-ticker");
    public TextElement cashNeeded = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(1) > form > div:nth-child(2) > table > tbody > tr:nth-child(6) > td.mds-td_trx.mds-td--right_trx > div > span");
    public TextElement cashToInvest = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(1) > form > div:nth-child(2) > table > tbody > tr:nth-child(7) > td.mds-td_trx.mds-td--right_trx > div > span.negative-ticker");
    public TextElement TRXCriticalErrors = new TextElement("#trx-errors");
    public TextElement PASCriticalErrors = new TextElement("#pas-errors");
    public TextElement valueManaged = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(3) > table > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement valueExcluded = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(3) > table > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement cashManaged = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(4) > table > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement cashExcluded = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(4) > table > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement taxableGainsShortTerm = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(2) > div");
    public TextElement nonTaxableGainsShortTerm = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(5) > table > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement taxableGainsLongTerm = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(5) > table > tbody > tr:nth-child(2) > td:nth-child(2) > div");
    public TextElement nonTaxableGainsLongTerm = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(5) > table > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement lastRebalanceDate = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(6) > table > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement lastTransactionDate = new TextElement("#vue-route > div > div.container.main-container.padding-none > div > div:nth-child(2) > div:nth-child(6) > table > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div");
    public ValueElement maxGain = new ValueElement("#mgains-amount");
    public ValueElement maxGainTax = new ValueElement("#mgains-tax-amount");
    public ValueElement ordinaryTaxRate = new ValueElement("#taxrate-ordinary");
    public ValueElement capitalGainsTaxRate = new ValueElement("#taxrate-capgain");
    public ValueElement carryForwardLossShortTerm = new ValueElement("#caploss-sterm");
    public ValueElement carryForwardLossLongTerm = new ValueElement("#caploss-lterm");
}