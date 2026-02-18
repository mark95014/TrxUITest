using System;
using System.Collections.Generic;
using System.Text;
using TrxUITest.src.utils.PageData.Elements;

public class SecuritySettingsPageData : PageData
{
    public TextElement title= new TextElement("#sec-detail-settingsmodule-cont-header");
    public TextElement description = new TextElement("#sec-detail-summarymodule-cont-header");
    CurrencyFormatElement price = new CurrencyFormatElement("#vue-route > div > div > div.col-sm-4 > div > section > div:nth-child(1); > div.col-sm-6 > span");
    //Activate these when necessary
    //cusp: public TextElement = new TextElement("#vue-route > div > div > div.col-sm-4 > div > section > div:nth-child(2); > div.col-sm-5 > span");
    //securityType: public TextElement = new TextElement("#vue-route > div > div > div.col-sm-4 > div > section > div:nth-child(2); > div.col-sm-6 > span");
    //countsAs: public ValueElement = new ValueElement("#sec-detail-subclass-select");
    //name: public TextElement = new TextElement("#vue-route > div > div > div.col-sm-4 > div > section > div:nth-child(3); > div.col-sm-6 > span");
    public ValueElement redemptionFeePenaltyNever = new ValueElement("#sec-detail-redfees-radios > span:nth-child(1); > label > span > span.mds-form__radio-button-visual");
    public ValueElement redemptionFeePenaltyInterval = new ValueElement("#sec-detail-redfees-radios > span:nth-child(2); > label > span > span.mds-form__radio-button-visual");
    public ValueElement redemptionFeePenaltyAlways = new ValueElement("#sec-detail-redfees-radios > span:nth-child(3); > label > span > span.mds-form__radio-button-visual");
    public ValueElement redemptionFeePenaltyPercent = new ValueElement("#sec-detail-redfees-percent-input");
    public ValueElement redemptionFeePenaltyDays = new ValueElement("#sec-detail-redfees-days-input");
    public ValueElement mustSellButton = new ValueElement("#sec-detail-sellflag-radios > span:nth-child(2) > label > span > span.mds-form__radio-button-visual");
    public ValueElement doNotSellButton = new ValueElement("#sec-detail-sellflag-radios > span:nth-child(1) > label > span > span.mds-form__radio-button-visual");
    public ValueElement okToSellButton = new ValueElement("#sec-detail-sellflag-radios > span:nth-child(3) > label > span > span.mds-form__radio-button-visual");
    public ValueElement prioritySellButton = new ValueElement("#sec-detail-sellflag-radios > span:nth-child(4) > label > span > span.mds-form__radio-button-visual");
}