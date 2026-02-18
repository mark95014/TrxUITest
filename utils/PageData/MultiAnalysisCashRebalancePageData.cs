using TrxUITest.src.utils.PageData.Elements;

public class MultiAnalysisCashRebalancePageData : PageData
{
    public TextElement title = new TextElement("#multi-cash-modal-header");
    public SimpleGridElement grid = new SimpleGridElement("#multi-cash-modal > div.mds-modal__wrapper > section > div > div > div > div:nth-child(1) > div:nth-child(4)");
}