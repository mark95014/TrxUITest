using TrxUITest.src.utils.PageData.Elements;

public class TradingOverridePageData : PageData
{
    public TextElement title = new TextElement("#override-trades-modal h2 > span");
    public TextElement symbol = new TextElement("#override-trades-modal > div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(3) > div.mds-form__field-group.mds-form--error.mds-label-inline > label");
    public TextElement account = new TextElement("#override-trades-modal > div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(1) > div.col-sm-4 > div.mds-form__field-group.mds-form--error.mds-label-inline > label");
    public TextElement subClass = new TextElement("#override-trades-modal > div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(4) > div.mds-form__field-group.mds-form--error.mds-label-inline > label");
    public TextElement type = new TextElement("#override-trades-modal > div > div > section > div.mds-section__content_trx > div > div:nth-child(2) > div:nth-child(1) > div.col-sm-3 > div.mds-form__field-group.mds-form--error.mds-label-inline > label");
}