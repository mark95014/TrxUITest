using TrxUITest.src.utils.PageData.Elements;

    public class MsReportPageEQData : PageData
    {
    //public TextElement title = new TextElement("#sal-components-quote > div > div:nth-child(2) > div > div.sal-component-header.sal-component-quote-header.ng-scope > div > div.security-info-panel-left.sal-column.sal-small-9.sal-medium-10.sal-large-10 > span.security-info-name.ng-binding");
    public TextElement title = new TextElement(".security-info-name");
    public TextElement symbol = new TextElement(".security-info-symbol");
}