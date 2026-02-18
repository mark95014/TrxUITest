using TrxUITest.src.utils.PageData.Elements;

class MultiAnalysisRebalancePageData : PageData
{
    public TextElement title = new TextElement("#multi-rebal-modal-header");
    public SimpleGridElement grid = new SimpleGridElement("#multi-rebal-modal > div.mds-modal__wrapper > section > div > div > div > div:nth-child(1) > div:nth-child(4)");
}