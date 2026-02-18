using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace TrxUITest.src.utils
{
    public static class SeleniumHelpers
    {
        static readonly bool debug = true;

        public static void Hover(string selector)
        {
            IWebElement element = SeleniumHelpers.FindElement(selector);
            Actions actions = new Actions(Test.driver);
            actions.MoveToElement(element).Perform();
        }

        public static bool WaitForElementToContain(string selector, string text, int timeoutInSeconds = 60)
        {
            const int timeDecrement = 1000;
            int timeoutMilliseconds = 1000 * timeoutInSeconds;
            Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeDecrement);

            while (timeoutMilliseconds > 0)
            {
                if (Test.driver.FindElement(By.CssSelector(selector)).Text.Contains(text)) return true;
                Thread.Sleep(timeDecrement);
                timeoutMilliseconds -= timeDecrement;
            }

            return false;
        }

        //remove name parameter after this method is proven to work reliably. name is just there for debugging. ???
        public static void WaitForElementToDisappear(string selector, int timeoutInSeconds = 60)
        {
            if (debug) TestContext.Progress.WriteLine($"Begin ToDisappear() element");

            const int timeDecrement = 1000;
            int timeoutMilliseconds = 1000 * timeoutInSeconds;

            Thread.Sleep(2000);

            Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeDecrement);

            if (debug) TestContext.Progress.WriteLine($"Starting loop to wait for element to disappear");

            while (timeoutMilliseconds > 0) //Wait for it to disappear
            {
                try
                {
                    IWebElement element = Test.driver.FindElement(By.CssSelector(selector));

                    try
                    {
                        if (!element.Displayed)
                        {
                            if (debug) TestContext.Progress.WriteLine($"Element is there, but not visible");
                            break;
                        }
                        else
                        {
                            if (debug) TestContext.Progress.WriteLine($"Element is still there");
                            Thread.Sleep(1000);
                        }
                    }
                    catch (StaleElementReferenceException)
                    {
                        if (debug) TestContext.Progress.WriteLine($"Element is there, but stale");
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    if (debug) TestContext.Progress.WriteLine($"Element went away");
                    break;
                }
                timeoutMilliseconds -= timeDecrement;
            }

            if (timeoutMilliseconds <= 0)
            {
                TestContext.Progress.WriteLine($"Thread timed out");
            }
        }

        public static IWebElement FindElement(string selector, int timeoutSeconds = 60, bool useXpath = false)
        {
            TimeSpan saveTimeout = Test.driver.Manage().Timeouts().ImplicitWait;
            Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutSeconds);

            IWebElement element;

            if (useXpath)
            {
                element = Test.driver.FindElement(By.XPath(selector));
            }
            else
            {
                element = Test.driver.FindElement(By.CssSelector(selector));
            }

            Test.driver.Manage().Timeouts().ImplicitWait = saveTimeout;

            return element;
        }

        public static ReadOnlyCollection<IWebElement> FindElements(string selector, int timeoutSeconds = 60)
        {
            ReadOnlyCollection<IWebElement> pageCountElements = Test.driver.FindElements(By.CssSelector(selector));
            return pageCountElements;
        }

        //Selects first option which matches, in the case where multiple options match.
        public static void SelectOptionByText(string selector, string text)
        {
            IReadOnlyCollection<IWebElement> options = Test.driver.FindElements(By.CssSelector(selector + " option"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Contains(text))
                {
                    option.Click();
                    break;
                }
            }
        }

        public static bool WaitForElementToBeVisible(string selector, int timeoutInSeconds = 60)
        {
            const int timeDecrement = 1000;
            int timeoutMilliseconds = 1000 * timeoutInSeconds;
            Test.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeDecrement);

            while (timeoutMilliseconds > 0)
            {
                if (Test.driver.FindElement(By.CssSelector(selector)).Displayed) return true;
                Thread.Sleep(timeDecrement);
                timeoutMilliseconds -= timeDecrement;
            }

            return false;
        }

        public static IWebElement ClearField(string selector, bool useXpath = false)
        {
            IWebElement element = FindElement(selector, useXpath: useXpath);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            return element;
        }

        public static void SelectOptionByValue(string selector, string value, bool escape = true)
        {
            SeleniumHelpers.WaitForElementToBeVisible(selector);
            var selectElement = new SelectElement(SeleniumHelpers.FindElement(selector));
            selectElement.SelectByValue(value);
        }
    }
}