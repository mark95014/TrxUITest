using TrxUITest.src.utils.PageData.Elements;

public class SecuritiesPageData : PageData
{
    public ColumnHeaderElement symbolHeader = new ColumnHeaderElement("#securitiesGrid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div.tg-column-name");
    public TextElement title = new TextElement("#bread-crumb-title");
    public SimpleGridElement grid = new SimpleGridElement("#vue-route > div:nth-child(4) > div");
}