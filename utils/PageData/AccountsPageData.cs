using TrxUITest.src.utils.PageData.Elements;

public class AccountsPageData : PageData
{
    public TextElement title = new TextElement("#bread-crumb-title");
    public SimpleGridElement grid = new SimpleGridElement("#vue-route > div:nth-child(2) > div");
}