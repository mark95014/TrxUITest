using OpenQA.Selenium;

namespace TrxUITest.src.utils
{
    public static class JavaScriptExec
    {
        private static IJavaScriptExecutor js = (IJavaScriptExecutor)Test.driver;

        public static void Click(string selector)
        {
            string clickCommand = "$('" + selector + "').click()";
            js.ExecuteScript(clickCommand);
        }

        public static void Execute(string command)
        {
            js.ExecuteScript(command);
        }
    }
}
