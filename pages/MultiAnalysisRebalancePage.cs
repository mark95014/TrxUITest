using OpenQA.Selenium;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public class MultiAnalysisRebalancePage : MultiAnalysisRebalancePageBase
    {
        public override void WaitForPageToLoad()
        {
            string titleSelector = new MultiAnalysisRebalancePageData().title.selector;
            Test.driver.FindElement(By.CssSelector(titleSelector));
        }

        public MultiAnalysisRebalancePage()
        {
            Selectors.exitButton = "#multi-rebal-modal button > span > svg";
            Selectors.createProposalButton = "#multi-rebal-create-proposal";
            Selectors.spinner = "#rebal-process-spinner";
            Selectors.rebalanceSetFilter = "#aeGrid-filter-RebalanceSet";
            Selectors.modalHeader = "#multi-rebal-modal-header";
        }
    }
}