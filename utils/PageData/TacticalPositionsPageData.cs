using TrxUITest.src.utils.PageData.Elements;

public class TacticalPositionsPageData: PageData
{
    public TextElement title = new TextElement("#bread-crumb-title");
    public SimpleGridElement grid = new SimpleGridElement("#mds-page-shell-content > main > div.page-router-wrapper > div > div:nth-child(2) > div");
    public CheckboxElement selectAllCheckbox = new CheckboxElement("#requested-positions-grid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div > div");
}