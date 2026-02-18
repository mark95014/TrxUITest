using OpenQA.Selenium;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.Pages
{
    class LoginPage
    {
        public static class Selectors
        {
            public static string userNameSelector = "#login-u-input";
            public static string passwordSelector = "#login-up-input";
            public static string recaptchaAnchorSelector = "#recaptcha-anchor";
            public static string loginButtonSelector = "#login-btn";
        }

        public static void LogIn(string webURL, string trxUserName, string trxPassword)
        {
            Test.driver.Navigate().GoToUrl(webURL);
            Test.driver.Navigate().Refresh();

            var userNameElement = SeleniumHelpers.FindElement((Selectors.userNameSelector));
            userNameElement.Click();
            userNameElement.SendKeys(trxUserName);

            var passwordElement = Test.driver.FindElement(By.CssSelector(Selectors.passwordSelector));
            passwordElement.Click();
            passwordElement.SendKeys(trxPassword);

            Test.driver.SwitchTo().Frame(0);
            Test.driver.FindElement(By.CssSelector(Selectors.recaptchaAnchorSelector)).Click();

            Thread.Sleep(2000);
            Test.driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);

            if (Test.environment == "prod") Thread.Sleep(15000); //Wait for user to respond to Capthca manually

            Test.driver.FindElement(By.CssSelector(Selectors.loginButtonSelector)).Click();
        }
	}
}