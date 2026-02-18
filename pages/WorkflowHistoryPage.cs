using System;
using System.Collections.Generic;
using System.Text;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class WorkflowHistoryPage
    {
        public static class Selectors
        {
            public static readonly string exitButton = "#edit-prop-workflow-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg";
            public static readonly string descriptionColumnHeader = "#proposal-history-workflow-grid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-1.tg-h-0 > div > div";
        }

        public static void WaitForPageToLoad()
        {
            WorkflowHistoryPageData pageData = new WorkflowHistoryPageData();
            SeleniumHelpers.FindElement(pageData.title.selector);
            SeleniumHelpers.FindElement(Selectors.descriptionColumnHeader).Click(); //sort
        }

        public static void VerifyPage()
        {
            WaitForPageToLoad();
            CommonVerifyPage.Verify(new WorkflowHistoryPageData());
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButton).Click();
        }
    }
}