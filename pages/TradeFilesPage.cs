using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System.IO;
using System.Threading;
using TrxUITest.src.utils;

namespace TrxUITest.src.pages
{
    public static class TradeFilesPage
    {
        public static class Selectors
        {
            public static readonly string tradeFilesModal = "#trade-prop-tradefiles-modal-header";
            public static readonly string tradeFileColumnHeader = "#trade-files-grid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-0.tg-h-0 > div > div.tg-column-name";
            public static readonly string tradeFilesModalExitButton = "#trade-prop-tradefiles-modal button > span > svg > path";
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.WaitForElementToContain(Selectors.tradeFilesModal, "Trade Files", 300);
            SeleniumHelpers.FindElement(new TradeFilesPageData().tradeFilesDownloadGrid.selector);
            IWebElement columnHeaderElement = Test.driver.FindElement(By.CssSelector(Selectors.tradeFileColumnHeader));
            Thread.Sleep(1000);
            columnHeaderElement.Click(); //sort
        }

        public static void VerifyPage()
        {
            TradeFilesPageData data = new TradeFilesPageData();
            data.Get();
            SeleniumHelpers.FindElement(Selectors.tradeFilesModalExitButton).Click();

            string dataLabel = ExpectedResults.MakeDataLabel(data, Test.GetTestCaseId());

            if (Test.generateExpectedResults)
            {
                ExpectedResults.Append(data, dataLabel);
            }
            else
            {
                JObject expectedResults = (JObject)JsonConvert.DeserializeObject(File.ReadAllText(ExpectedResults.fileName));
                JObject expectedResult = (JObject)expectedResults[dataLabel];
                data.Verify(expectedResult, dataLabel);
            }
        }
    }
}