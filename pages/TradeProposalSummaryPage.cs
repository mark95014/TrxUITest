using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class TradeProposalSummaryPage
    {
        public static class Selectors
        {
            readonly public static string exitButton = "#trade-prop-summary-modal button > span > svg > path";
        }

        public static void WaitForPageToLoad()
        {
            TradeProposalSummaryPageData pageData = new TradeProposalSummaryPageData();
            SeleniumHelpers.FindElement(pageData.title.selector);
            SeleniumHelpers.WaitForElementToContain(pageData.title.selector, "Summary", 10);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new TradeProposalSummaryPageData());
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButton).Click();
        }
    }
}