using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.pages
{
    public class TradingConstraintsPageData : PageData
    {
        public TextElement title = new TextElement("[id*='prop-constraints-modal-header']");
        public CsvElement grid = new CsvElement("#downcsv-proposal-history-constraints-grid-action-bar-top > span:nth-child(2)", "history-constraints.csv");
    }
}