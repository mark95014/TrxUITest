using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class ErrorsPage
    {
        public static ErrorsPageData data = new ErrorsPageData();

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.FindElement(data.title.selector);
        }
    
        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(data);
        }

        public static void Exit()
        {
                Test.driver.Navigate().Back();
        }
    }
}