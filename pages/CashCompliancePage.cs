using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class CashCompliancePage
    {
        public static class Selectors
        {
            public static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void WaitForPageToLoad()
        {
            CashCompliancePageData data = new CashCompliancePageData();
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.WaitForElementToContain(data.title.selector, "Cash Needs >");
            Thread.Sleep(1000);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new CashCompliancePageData());
        }
    }
}