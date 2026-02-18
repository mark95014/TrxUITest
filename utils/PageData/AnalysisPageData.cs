using TrxUITest.src.utils.PageData.Elements;

public class AnalysisPageData : PageData
{
    public TextElement title = new TextElement("#bread-crumb-title");
    public SimpleGridElement grid = new SimpleGridElement("#vue-route > div:nth-child(3)");
}