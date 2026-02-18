using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class TlhCompliancePage
    {
        public static class Selectors
        {
            public static string spinner = "#edge > div > div > div.loader-overlay > div > div";
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.WaitForElementToContain(new TlhCompliancePageData().title.selector, "Tlh Needs >");
            Thread.Sleep(1000);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new TlhCompliancePageData());
        }
    }
}