using OpenQA.Selenium;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public class MultiAnalysisCashRebalancePage : MultiAnalysisRebalancePageBase
    {
        public override void WaitForPageToLoad()
        {
            string titleSelector = new MultiAnalysisCashRebalancePageData().title.selector;
            Test.driver.FindElement(By.CssSelector(titleSelector));
        }

        public MultiAnalysisCashRebalancePage()
        {
            Selectors.exitButton = "#multi-cash-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg > path";
            Selectors.createProposalButton = "#multi-cash-create-proposal";
            Selectors.numberOfProposals = "#multi-cash-selected > label";
            Selectors.spinner = "#cash-process-spinner";
            Selectors.modalHeader = "#multi-cash-modal-header";
        }
    }
}