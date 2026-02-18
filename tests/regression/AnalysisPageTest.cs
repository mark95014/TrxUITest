using NUnit.Framework;
using TrxUITest.src.utils;
using TrxUITest.src.pages;
using static TrxUITest.src.pages.AnalysisPageTestBase;

namespace TrxUITest
{

    [TestFixture]

    class AnalysisPageTest : BaseTest
    {
        [TestCase(3226857)]
        public void ClientSort(int testCaseId)
        {
            AnalysisPageTestBase.ColumnSortTestCase(AnalysisPage.Selectors.clientSort);
        }

        [TestCase(3226837)]
        public void AllExceptOpenProposals(int testCaseId)
        {
            AnalysisPageTestBase.CheckboxTestCase(new AnalysisPageTestBase.Checkbox[] {AnalysisPageTestBase.Checkbox.oob, AnalysisPageTestBase.Checkbox.cash, AnalysisPageTestBase.Checkbox.tlh});
        }

        [TestCase(3226834)]
        public void AllUnchecked(int testCaseId)
        {
            AnalysisPageTestBase.CheckboxTestCase(new AnalysisPageTestBase.Checkbox[] {});
        }

        [TestCase(3226835)]
        public void CashCheckbox(int testCaseId)
        {
            AnalysisPageTestBase.CheckboxTestCase(new AnalysisPageTestBase.Checkbox[] { Checkbox.cash });
        }

        [TestCase(3226836)]
        public void TlhCheckbox(int testCaseId)
        {
            AnalysisPageTestBase.CheckboxTestCase(new AnalysisPageTestBase.Checkbox[] { Checkbox.tlh });
        }

         [TestCase(3226831)]
        public void OobCheckbox(int testCaseId)
        {
            AnalysisPageTestBase.CheckboxTestCase(new AnalysisPageTestBase.Checkbox[] { Checkbox.oob });
        }

        [TestCase(3226838)]
        public void AllChecked(int testCaseId)
        {
            AnalysisPageTestBase.CheckboxTestCase(new AnalysisPageTestBase.Checkbox[] { Checkbox.oob, Checkbox.cash, Checkbox.tlh, Checkbox.openProposals });
        }

        [TestCase(3226847)]
        public void FilterByClientId(int testCaseId)
        {
            AnalysisPageTestBase.FilterTestCase(AnalysisPage.Selectors.id, "9999");
        }

        [TestCase(3226848)]
        public void FilterByClientName(int testCaseId)
        {
            AnalysisPageTestBase.FilterTestCase(AnalysisPage.Selectors.clientName, "Ke");
        }

        [TestCase(3226849)]
        public void FilterByModel(int testCaseId)
        {
            AnalysisPageTestBase.FilterTestCase(AnalysisPage.Selectors.model, "40/60");
        }

        [TestCase(3226850)]
        public void FilterByAdvisor(int testCaseId)
        {
            AnalysisPageTestBase.FilterTestCase(AnalysisPage.Selectors.advisor, "AA");
        }

        [TestCase(3226851)]
        public void FilterByValue(int testCaseId)
        {
            AnalysisPageTestBase.FilterTestCase(AnalysisPage.Selectors.value, "3000000");
        }

        [TestCase(3226852)]
        public void FilterByOobPercent(int testCaseId)
        {
            AnalysisPageTestBase.FilterTestCase(AnalysisPage.Selectors.classOOBPercent, "9");
        }

        [TestCase(3226853)]
        public void FilterByOobAmount(int testCaseId)
        {
            AnalysisPageTestBase.FilterTestCase(AnalysisPage.Selectors.classOOBAmount, "80000");
        }

        [TestCase(3226855)]
        public void FilterByMix(int testCaseId)
        {
            AnalysisPageTestBase.FilterByMix();
        }

        [TestCase(3226856)]
        public void SortById(int testCaseId)
        {
            AnalysisPageTestBase.ColumnSortTestCase(AnalysisPage.Selectors.idSort);
        }

        [TestCase(3226858)]
        public void SortByModel(int testCaseId)
        {
            AnalysisPageTestBase.ColumnSortTestCase(AnalysisPage.Selectors.modelSort);
        }

        [TestCase(3226859)]
        public void SortByOOBPercent(int testCaseId)
        {
            AnalysisPageTestBase.ColumnSortTestCase(AnalysisPage.Selectors.classOOBPercentSort);
        }

        [TestCase(3226860)]
        public void SortByValue(int testCaseId)
        {
            AnalysisPageTestBase.ColumnSortTestCase(AnalysisPage.Selectors.valueSort);
        }
    }
}