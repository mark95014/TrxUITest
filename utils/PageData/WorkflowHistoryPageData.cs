using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.pages
{
    public class WorkflowHistoryPageData: PageData
    {
        public TextElement title = new TextElement("[id*='prop-workflow-modal-header'");
        public SimpleGridElement historyGrid = new SimpleGridElement(" div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg");
    }
}