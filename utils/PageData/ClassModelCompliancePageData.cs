using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.tests.utils
{
    public class ClassModelCompliancePageData : PageData
    {
        public SimpleGridElement classComplianceGrid = new SimpleGridElement("#class-grid-wrapper");
        public LegendElement targetClassLegend = new LegendElement("#asset-class-target-chart-legend > svg text.legend-text.legend-label");
        public LegendElement currentClassLegend = new LegendElement("#asset-class-current-chart-legend > svg text.legend-text.legend-label");
    }
}