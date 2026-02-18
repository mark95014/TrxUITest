using OpenQA.Selenium;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData;

namespace TrxUITest.src.pages
{
    public class MultiAnalysisTlhRebalancePage : MultiAnalysisRebalancePageBase
    {
        public override void WaitForPageToLoad()
        {
            string titleSelector = new MultiAnalysisTlhRebalancePageData().title.selector;
            Test.driver.FindElement(By.CssSelector(titleSelector));
        }

        public MultiAnalysisTlhRebalancePage()
        {
            Selectors.exitButton = "#multi-tlh-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            Selectors.createProposalButton = "#multi-tlh-create-proposal";
            Selectors.numberOfProposals = "#multi-tlh-selected > label";
            Selectors.spinner = "#tlh-process-spinner";
            Selectors.modalHeader = "#multi-tlh-modal-header";
        }
    }
}