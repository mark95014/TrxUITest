using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using OpenQA.Selenium;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests

{

    public class RebalanceSingleTestBase
    {
        public readonly static AccountSettings accountSettingsMinimum = new AccountSettings(new string[] { "9999-0064" }, "8194");
        public readonly static AccountSettings accountSettingsMidpoint = new AccountSettings(new string[] { "9999-0064" }, "8194");
        public readonly static AccountSettings accountSettingsMaximum = new AccountSettings(new string[] { "9999-0134" }, "8205");
        public readonly static AccountSettings resetAccountSettings = new AccountSettings(new string[] { "9999-0064" }, "8194");
        public readonly static ClientSettings clientSettings1 = new ClientSettings(null, null, null, "2014 - 50/50", null);
        public readonly static ClientSettings clientSettings2 = new ClientSettings(null, null, null, "AA FUND: 60/40", null);
        public readonly static ClientSettings clientSettings3 = new ClientSettings(null, null, "buyset1", null, null);
        public readonly static ClientSettings clientSettings4 = new ClientSettings(null, null, null, "Balanced", null);
        public readonly static ClientSettings clientSettings5 = new ClientSettings(null, null, "equiv", null, null);
        public readonly static SecuritySettings securitySettings1 = new SecuritySettings("ADFIX", SellFlag.MustSell);
        public readonly static TradingOverrideSettings doNotSellSettings = new TradingOverrideSettings("8201", "DFREX", "Standard", "Do Not Sell");

        public static void Init()
        {
            RebalanceSingleTestBase.accountSettingsMinimum.rmdMinimum = "10000";
            RebalanceSingleTestBase.accountSettingsMinimum.rmdMinimum = "15000";
            RebalanceSingleTestBase.accountSettingsMinimum.cashSetasideGoal = "Rebalance to Minimum";


            RebalanceSingleTestBase.accountSettingsMidpoint.rmdMinimum = "10000";
            RebalanceSingleTestBase.accountSettingsMidpoint.rmdMinimum = "15000";
            RebalanceSingleTestBase.accountSettingsMidpoint.cashSetasideGoal = "Rebalance to Midpoint";

            RebalanceSingleTestBase.accountSettingsMaximum.rmdMinimum = "10000";
            RebalanceSingleTestBase.accountSettingsMaximum.rmdMinimum = "15000";
            RebalanceSingleTestBase.accountSettingsMaximum.cashSetasideGoal = "Rebalance to Maximum";

            RebalanceSingleTestBase.resetAccountSettings.rmdMinimum = "0";
            RebalanceSingleTestBase.resetAccountSettings.rmdMinimum = "0";
            RebalanceSingleTestBase.resetAccountSettings.cashSetasideGoal = "(select an option)";

            //TradeProposalsPage.GoTo();
            //TradeProposalsPage.CancelProposals();
        }

        public void UpdateAccountSettings(AccountSettings accountSettings)
        {
            foreach (string accountId in accountSettings.accountIds)
            {
                AccountPage.GoTo(accountId);
                AccountPage.Update(accountSettings);
            }
        }

        public void UpdateClientSettings(string clientId, ClientSettings clientSettings)
        {
            ClientSettingsPage.UpdateClientSettings(clientId, clientSettings);
        }

        public void UpdateSecuritySettings(SecuritySettings securitySettings)
        {
            SecuritySettingsPage.UpdateSecuritySettings(securitySettings);
        }

        public void TestCase(string clientId, bool locationOptimization = false, ClientSettings clientSettings = null,
            SecuritySettings securitySettings = null, AccountSettings accountSettings = null, bool expectTrades = true)
        {
            ModelRebalanceWorkflow workflow = new ModelRebalanceWorkflow(clientId, locationOptimization, expectTrades);
            Thread.Sleep(1000);

            if (clientSettings != null) { UpdateClientSettings(clientId, clientSettings); }
            if (securitySettings != null) { UpdateSecuritySettings(securitySettings); }
            if (accountSettings != null) { UpdateAccountSettings(accountSettings); }

            workflow.Execute();
        }

        public void CashTestCase(string clientId, bool locationOptimization = false, ClientSettings clientSettings = null,
            SecuritySettings securitySettings = null, AccountSettings accountSettings = null)
        {
            CashRebalanceWorkflow workflow = new CashRebalanceWorkflow(clientId);
            Thread.Sleep(1000);

            if (clientSettings != null) UpdateClientSettings(clientId, clientSettings);
            if (securitySettings != null) UpdateSecuritySettings(securitySettings);
            if (accountSettings != null) UpdateAccountSettings(accountSettings);

            workflow.Execute();
            Thread.Sleep(2000);

            if (accountSettings != null) UpdateAccountSettings(RebalanceSingleTestBase.resetAccountSettings);
        }

        public void OverrideTestCase(TradingOverrideSettings settings)
        {
            ClientPage.GoTo(settings.clientId);
            IWebElement overridesButtonElement = SeleniumHelpers.FindElement(ClientPage.Selectors.viewOverridesButton);
            overridesButtonElement.Click();

            TradingOverridesPage.WaitForPageToLoad();
            TradingOverridesPage.FilterBySymbol(settings.symbol);
            SeleniumHelpers.FindElement(TradingOverridesPage.Selectors.securityDescription);
            JavaScriptExec.Click(TradingOverridesPage.Selectors.securityDescription);

            TradingOverridePage.WaitForPageToLoad();

            if (settings.buyFlag != null)
            {
                SeleniumHelpers.SelectOptionByValue(TradingOverridePage.Selectors.buySetting, settings.buyFlag, true);
                //SeleniumHelpers.FindElement(TradingOverridePage.Selectors.buySetting).SendKeys(settings.buyFlag);
            }

            if (settings.sellFlag != null)
            {
                SeleniumHelpers.SelectOptionByValue(TradingOverridePage.Selectors.sellSetting, settings.sellFlag, true);
                //SeleniumHelpers.FindElement(TradingOverridePage.Selectors.sellSetting).SendKeys(settings.sellFlag);
            }

            if (settings.buyFlag != null || settings.sellFlag != null)
            {
                IWebElement addOverrideButton = SeleniumHelpers.FindElement(TradingOverridePage.Selectors.addOverrideButton);
                addOverrideButton.Click();
                SeleniumHelpers.WaitForElementToDisappear(ClientPage.Selectors.spinner);
                SeleniumHelpers.FindElement("#delete-override-btn > span");
            }

            SeleniumHelpers.FindElement(TradingOverridePage.Selectors.exitButton).Click();

            ModelRebalanceWorkflow workflow = new ModelRebalanceWorkflow(settings.clientId, false);
            
            workflow.Execute();
        }
    }
}