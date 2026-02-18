using TrxUITest.src.utils.PageData.Elements;

public class TacticalBlotterPageData: PageData
{
    public TextElement title = new TextElement("#bread-crumb-title");
    public CheckboxElement selectAllCheckbox = new CheckboxElement("#proposed-blotter-grid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div > div");
    public CsvElement grid = new CsvElement("#downcsv-proposed-blotter-grid-action-bar-top > span", "proposed-blotter.csv");
}