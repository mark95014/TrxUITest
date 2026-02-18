using TrxUITest.src.utils.PageData.Elements;

class MultiAnalysisTlhRebalancePageData : PageData
{
    public TextElement title = new TextElement("#multi-tlh-modal-header");
    public SimpleGridElement grid = new SimpleGridElement("multi-tlh > div:nth-child(4)");
}