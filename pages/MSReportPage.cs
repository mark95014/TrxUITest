using OpenQA.Selenium;
using System;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class MSReportPage
    {
        public static PageData data;

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(5000);
            //TimeSpan saveTimeout = Test.driver.Manage().Timeouts().ImplicitWait;
            //Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Test.driver.SwitchTo().Window(Test.driver.WindowHandles[1]); //Report tab

            IWebElement form1 = SeleniumHelpers.FindElement("#form1", 120);
            //IWebElement form1 = Test.driver.FindElement(By.Id("form1"));

            string action = form1.GetAttribute("action");
            if (action.Contains("EQ"))
            {
                data = new MsReportPageEQData();
            }
            else if (action.Contains("MF"))
            {
                data = new MsReportPageMFData();
            }
            else
            {
                Result result = new Result (false, $"Invalid Report Type: {action}. Should be EQ or MF");
                Test.results.Add(result);
            }

            //Test.driver.Manage().Timeouts().ImplicitWait = saveTimeout;
            Thread.Sleep(5000);
        }
    }
}