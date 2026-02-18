using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.tests;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest
{
    public static class TacticalTestBase
    {
        public static SecuritySettings securitySettingsDoNotSell = new SecuritySettings("ACBPX", SellFlag.DoNotSell);
        public static SecuritySettings securitySettingsOkToSell = new SecuritySettings("ACBPX", SellFlag.OkToSell);
        public static ClientSettings clientSettingsLocked = new ClientSettings(null, null, null, null, "Locked");
        public static ClientSettings clientSettingsHidden = new ClientSettings(null, null, null, null, "Hidden");
        public static ClientSettings clientSettingsNoModel = new ClientSettings(null, null, null, "Select Model", null);

        public static void WaitForSpinner(string selector = null)
        {
            selector ??= "#edge > div > div > div.loader-overlay > div > div";
            Thread.Sleep(5000);
            SeleniumHelpers.WaitForElementToDisappear(selector, 300000);
        }

        public static void UpdateClientSettings(string clientId, ClientSettings clientSettings)
        {
            ClientSettingsPage.UpdateClientSettings(clientId, clientSettings);
        }

        public static void ClearTheBlotter()
        {
            //The select all checkbox on the blotter does not have the attribute "checked", so I could not use the
            //checkBoxElement to set the checkbox. So, I am relying on it already being checked in processTrades().
            // blotterPage.waitForElementPresent(blotterPageData.selectAllCheckbox.selector)
            // blotterPageData.selectAllCheckbox.check(blotterPage, browser)
            SeleniumHelpers.FindElement(TacticalBlotterPage.Selectors.deleteSelectionsButton).Click();
            Thread.Sleep(1000);
            WaitForSpinner(TacticalBlotterPage.Selectors.spinner);
        }

        public static void FilterPositions(Filter filter)
        {
            SeleniumHelpers.FindElement(TacticalPositionsPage.Selectors.openPositionsButton).Click();
            SeleniumHelpers.ClearField(TacticalPositionsPage.Selectors.valueFilter);
            SeleniumHelpers.ClearField(TacticalPositionsPage.Selectors.advisorFilter);
            SeleniumHelpers.ClearField(TacticalPositionsPage.Selectors.accountFilter);

            if (filter.subClass != null)
            {
                SeleniumHelpers.SelectOptionByValue(TacticalPositionsPage.Selectors.subClassPulldown, filter.subClass);
                WaitForSpinner();
                Thread.Sleep(1000);
            }

            if (filter.symbol != null)
            {
                SeleniumHelpers.SelectOptionByValue(TacticalPositionsPage.Selectors.symbolPulldown, filter.symbol);
                WaitForSpinner();
                Thread.Sleep(1000);
            }

            if (filter.accounts != null)
            {
                Thread.Sleep(1000);

                foreach (string account in filter.accounts)
                {
                    Thread.Sleep(1000);
                    SeleniumHelpers.FindElement(TacticalPositionsPage.Selectors.accountFilter).SendKeys(account);
                    Thread.Sleep(1000);

                    ReadOnlyCollection<IWebElement> elements = SeleniumHelpers.FindElements(TacticalPositionsPage.Selectors.firstRowCheckbox);
                    if (elements.Count > 0)
                    {
                        elements[0].Click();
                        //SeleniumHelpers.FindElement(TacticalPositionsPage.Selectors.firstRowCheckbox).Click();
                        Thread.Sleep(1000);

                        IWebElement accountFilterElement = SeleniumHelpers.FindElement(TacticalPositionsPage.Selectors.accountFilter);
                        accountFilterElement.Click();
                        SeleniumHelpers.ClearField(TacticalPositionsPage.Selectors.accountFilter);
                    }
                }
            }

            if (filter.value != null)
            {
                string valueSelector = TacticalPositionsPage.Selectors.valueFilter;
                Thread.Sleep(1000);
                SeleniumHelpers.FindElement(valueSelector).Click();
                SeleniumHelpers.FindElement(valueSelector).SendKeys(filter.value);
            }

            if (filter.advisorSet != null)
            {
                string advisorSelector = TacticalPositionsPage.Selectors.advisorFilter;
                Thread.Sleep(1000);
                SeleniumHelpers.FindElement(advisorSelector).Click();
                SeleniumHelpers.FindElement(advisorSelector).SendKeys(filter.advisorSet);
            }
        }

        public static bool HasTradesToProcess()
        {
            string selectedCountSelector = TacticalPositionsPage.Selectors.selectedCount;
            ReadOnlyCollection<IWebElement> selectedCountElements = SeleniumHelpers.FindElements(selectedCountSelector);
            return (selectedCountElements.Count > 0);
        }

        //Enter the trade on the Tactical Trade Detail page
        public static void CreateTrade(TacticalTrade trade)
        {
            //Create tactical trade
            IWebElement createTradeElement = SeleniumHelpers.FindElement(TacticalPositionsPage.Selectors.createTradeButton);
            SeleniumHelpers.WaitForElementToContain(TacticalPositionsPage.Selectors.createTradeButton, "Create Trade");
            createTradeElement.Click();
            if (trade != null)
            {
                TacticalTradePage.CreateTrade(trade);
            }
        }

        //Verify the blotter and the positions page after creating the trades. Then, create proposals, then verify the trade files.
        public static void ProcessTrades()
        {
            TacticalBlotterPageData pageData = new TacticalBlotterPageData();

            //Switch to blotter
            SeleniumHelpers.FindElement(TacticalPositionsPage.Selectors.blotterButton).Click();

            //Verify blotter
            TacticalBlotterPage.WaitForPageToLoad();
            SeleniumHelpers.FindElement(TacticalBlotterPage.Selectors.totalRecords);
            if (int.Parse(SeleniumHelpers.FindElement(TacticalBlotterPage.Selectors.totalRecords).Text) > 0)
            {
                TacticalBlotterPage.VerifyPage();
                SeleniumHelpers.FindElement(TacticalBlotterPage.Selectors.refreshButton).Click();
                TacticalBlotterPage.WaitForPageToLoad();

                SeleniumHelpers.FindElement(pageData.selectAllCheckbox.selector).Click();

                IWebElement createProposalsButton = SeleniumHelpers.FindElement(TacticalBlotterPage.Selectors.createProposalsButton);

                if (createProposalsButton.GetAttribute("disabled") == null)
                {
                    SeleniumHelpers.FindElement(TacticalBlotterPage.Selectors.createProposalsButton).Click();
                    Thread.Sleep(1000);
                    SeleniumHelpers.WaitForElementToDisappear(TacticalBlotterPage.Selectors.spinner);

                    TacticalBlotterPage.VerifyPage(); //Verify blotter again to see the "Proposal created" and other messages

                    SeleniumHelpers.FindElement(TacticalBlotterPage.Selectors.openPositionsButton).Click(); //Switch to positions page
                    TacticalPositionsPage.WaitForPageToLoad();
                    TacticalPositionsPage.VerifyPage(); //Verify positions again (messages may appear since first verification)

                    SeleniumHelpers.FindElement(TacticalPositionsPage.Selectors.blotterButton).Click(); //Go back to blotter
                    TacticalBlotterPage.WaitForPageToLoad();
                    SeleniumHelpers.FindElement(pageData.selectAllCheckbox.selector).Click();
                    ClearTheBlotter();

                    Thread.Sleep(1000);
                    new MultiTradeProposal().ProcessTrades();
                }
                else
                {
                    //No trades to process
                    ClearTheBlotter();
                }
            }
        }

        public static void TestCase(TacticalTrade[] trades)
        {
            TacticalPositionsPageData pageData = new TacticalPositionsPageData();

            TacticalPositionsPage.GoTo();

            foreach(TacticalTrade trade in trades)
            {
                TacticalPositionsPage.WaitForPageToLoad();

                FilterPositions(trade.filter);
                TacticalPositionsPage.VerifyPage();

                SeleniumHelpers.FindElement(TacticalPositionsPage.Selectors.firstPageButton).Click(); //rewind
                TacticalPositionsPage.WaitForPageToLoad();

                if (trade.filter.accounts == null)
                {
                    SeleniumHelpers.FindElement(pageData.selectAllCheckbox.selector).Click();
                }

                if (HasTradesToProcess())
                {
                    CreateTrade(trade);
                }

                Thread.Sleep(5000);
                SeleniumHelpers.WaitForElementToDisappear(TacticalPositionsPage.Selectors.spinner);
            }

            TacticalPositionsPage.WaitForPageToLoad();
            ProcessTrades();
        }
    }
}