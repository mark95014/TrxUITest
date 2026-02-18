using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.tests.utils
{
    public class SubclassModelCompliancePageData : PageData
    {
        public SimpleGridElement subclassComplianceGrid = new SimpleGridElement("#sub-class-grid-wrapper");
        public LegendElement targetSubclassLegend = new LegendElement("#asset-subclass-target-chart-legend > svg text.legend-text.legend-label");
        public LegendElement currentSubclassLegend = new LegendElement("#asset-subclass-current-chart-legend > svg text.legend-text.legend-label");
    }
}