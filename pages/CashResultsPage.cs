using System;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class CashResultsPage
    {
        public static class Selectors
        {
            public static readonly string spinner = "#edge > div > div > div.loader-overlay > div > div";
            public static readonly string exitButton = " div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg > path";
        }
        public static void WaitForPageToLoad()
        {
            CashResultsPageData data = new CashResultsPageData();
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.WaitForElementToContain(data.title.selector, "Cash Results");
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new CashResultsPageData());
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButton).Click();
        }
    }
}