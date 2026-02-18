using TrxUITest.src.utils.PageData.Elements;

public class ClientPositionsPageData: PageData
{
    public TextElement title = new TextElement("#positions-modal h2 > span");
    public SimpleGridElement grid = new SimpleGridElement("#positions-wrapper");
}