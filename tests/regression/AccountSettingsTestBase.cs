using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests.regression
{
    public class AccountSettingsTestBase
    {
        public static readonly AccountSettings accountSettingsChangeModel = new AccountSettings(new string[] { "9999-0003" }, "8186");
        public static readonly AccountSettings accountSettingsCantChangeModel = new AccountSettings(new string[] { "9999-0001" }, "8186");
        public static readonly AccountSettings accountSettingsTaxable = new AccountSettings(new string[] { "9999-0007" }, "8187");
        public static readonly AccountSettings accountSettingsBillingAccount = new AccountSettings(new string[] { "9999-0134" }, "8205");
        public static readonly AccountSettings accountSettingsRestrictedAccount = new AccountSettings(new string[] { "9999-0091" }, "8207");
        public static readonly AccountSettings accountSettingsSMA = new AccountSettings(new string[] { "9999-0068" }, "8195");
        public static readonly AccountSettings accountSettingsIRA = new AccountSettings(new string[] { "9999-0027" }, "8211");
        public static readonly AccountSettings accountSettingsUnmanaged = new AccountSettings(new string[] { "9999-0034" }, "8212");
        public static readonly AccountSettings accountSettingsMarginAccount = new AccountSettings(new string[] { "9999-0112" }, "8215");
        public static readonly AccountSettings accountSettingsNotMarginAccount = new AccountSettings(new string[] { "9999-0112" }, "8215");
        public static readonly AccountSettings accountSettingsMarginPercent = new AccountSettings(new string[] { "9999-0078" }, "8214");
        public static readonly AccountSettings accountSettingsTransactionCostsIncluded = new AccountSettings(new string[] { "9999-0001", "9999-0002", "9999-0003" }, "8186");
        public static readonly AccountSettings accountSettingsTransactionCostsAdded = new AccountSettings(new string[] { "9999-0001", "9999-0002", "9999-0003" }, "8186");
        public static readonly AccountSettings accountSettingsMasterAccount = new AccountSettings(new string[] { "9999-0042" }, "8190");
        public static readonly AccountSettings accountSettingsCashGoalGain = new AccountSettings(new string[] { "9999-0096", "9999-0097", "9999-0098", "9999-0099" }, "8197");
        public static readonly AccountSettings accountSettingsCashGoalReduce = new AccountSettings(new string[] { "9999-0096", "9999-0097", "9999-0098", "9999-0099" }, "8197");
        public static readonly AccountSettings accountSettingsMinimumTrans5043932 = new AccountSettings(new string[] { "9999-0113", "9999-0115" }, "8226");
        public static readonly AccountSettings accountSettingsMinimumTrans5043933 = new AccountSettings(new string[] { "9999-0113", "9999-0115" }, "8226");
        public static readonly AccountSettings accountSettingsMinimumTrans5043934 = new AccountSettings(new string[] { "9999-0113", "9999-0115" }, "8226");
        public static readonly AccountSettings accountSettingsMutualFundRounding10 = new AccountSettings(new string[] { "9999-0023", "9999-0024", "9999-0025", "9999-0026" }, "8208");
        public static readonly AccountSettings accountSettingsMutualFundRounding1000 = new AccountSettings(new string[] { "9999-0023", "9999-0024", "9999-0025", "9999-0026" }, "8208");

        public static void Init()
        {
            AccountSettingsTestBase.accountSettingsChangeModel.model = "AA FUND: 60/40";
            AccountSettingsTestBase.accountSettingsCantChangeModel.model = "AA FUND: 60/40";
            AccountSettingsTestBase.accountSettingsTaxable.category = "Taxable";
            AccountSettingsTestBase.accountSettingsBillingAccount.billingAccount = true;
            AccountSettingsTestBase.accountSettingsRestrictedAccount.restrictedAccount = true;
            AccountSettingsTestBase.accountSettingsRestrictedAccount.restrictedPlan = "Plan: Restricted Plan 1 | Desc.: Restricted Plan 1 Description";
            AccountSettingsTestBase.accountSettingsSMA.smaAccount = true;
            AccountSettingsTestBase.accountSettingsSMA.smaAllocations = new SMAAllocation[] { new SMAAllocation("GFI", "10"), new SMAAllocation("EME", "90")};
            AccountSettingsTestBase.accountSettingsIRA.category = "IRA/Retirement/Annuity/CRT";
            AccountSettingsTestBase.accountSettingsUnmanaged.managedAccount = false;
            AccountSettingsTestBase.accountSettingsMarginAccount.marginAccount = true;
            AccountSettingsTestBase.accountSettingsNotMarginAccount.marginAccount = false;
            AccountSettingsTestBase.accountSettingsMarginPercent.marginPercent = "5";
            AccountSettingsTestBase.accountSettingsTransactionCostsIncluded.buyTransactionCosts = "INCLUDED";
            AccountSettingsTestBase.accountSettingsTransactionCostsIncluded.sellTransactionCosts = "INCLUDED";
            AccountSettingsTestBase.accountSettingsTransactionCostsAdded.buyTransactionCosts = "ADD";
            AccountSettingsTestBase.accountSettingsTransactionCostsAdded.sellTransactionCosts = "ADD";
            AccountSettingsTestBase.accountSettingsMasterAccount.masterAccount = "123456";
            AccountSettingsTestBase.accountSettingsCashGoalGain.minimumCash = ".25";
            AccountSettingsTestBase.accountSettingsCashGoalGain.cashType = "% of Client";
            AccountSettingsTestBase.accountSettingsCashGoalGain.maximumCash = "1";
            AccountSettingsTestBase.accountSettingsCashGoalGain.cashGoal = "Rebalance to Minimum";
            AccountSettingsTestBase.accountSettingsCashGoalReduce.minimumCash = "0";
            AccountSettingsTestBase.accountSettingsCashGoalReduce.maximumCash = ".1";
            AccountSettingsTestBase.accountSettingsCashGoalReduce.cashGoal = "Rebalance to Maximum";
            AccountSettingsTestBase.accountSettingsMinimumTrans5043932.minimumTransactionDollars = "0";
            AccountSettingsTestBase.accountSettingsMinimumTrans5043932.minimumTransactionPercent = "0";
            AccountSettingsTestBase.accountSettingsMinimumTrans5043933.minimumTransactionDollars = "1000";
            AccountSettingsTestBase.accountSettingsMinimumTrans5043933.minimumTransactionPercent = "25";
            AccountSettingsTestBase.accountSettingsMinimumTrans5043933.minimumTransactionFlag = "user Greater";
            AccountSettingsTestBase.accountSettingsMinimumTrans5043934.minimumTransactionDollars = "100000";
            AccountSettingsTestBase.accountSettingsMinimumTrans5043934.minimumTransactionPercent = "25";
            AccountSettingsTestBase.accountSettingsMinimumTrans5043934.minimumTransactionFlag = "Dollar amt";
            AccountSettingsTestBase.accountSettingsMutualFundRounding10.mutualFundRounding = "Round to $10";
            AccountSettingsTestBase.accountSettingsMutualFundRounding1000.mutualFundRounding = "Round to $1000";
        }

        public void UpdateAccountSettings(AccountSettings accountSettings)
        {
            foreach (string accountId in accountSettings.accountIds)
            {
                AccountPage.GoTo(accountId);
                AccountPage.Update(accountSettings);
            }
        }

        public void UpdateCustodianSettings(CustodianSettings custodianSettings)
        {
            Test.driver.Navigate().GoToUrl(CustodianSettingsPage.url);
            CustodianSettingsPage.Update(custodianSettings);
        }

        public void VerifyAccountTestCase(AccountSettings accountSettings)
        {
            UpdateAccountSettings(accountSettings);

            foreach (string accountId in accountSettings.accountIds)
            {
                AccountsPage.GoTo();
                Thread.Sleep(1000);
                SeleniumHelpers.FindElement(AccountsPage.Selectors.accountsGrid);
                AccountsPage.FilterByAccountNumber(accountId);
                AccountsPage.VerifyPage();

                SeleniumHelpers.FindElement(AccountsPage.Selectors.firstAccount).Click();
                AccountPage.WaitForPageToLoad();
                AccountPage.VerifyPage();
            }
        }

        public void ChangeModelFailTestCase(AccountSettings accountSettings)
        {
            UpdateAccountSettings(accountSettings);
            Thread.Sleep(2000);
            string expectedMessage = "Could not split account to new household. Please see the Event Log on the Errors page for more information.";
            SeleniumHelpers.WaitForElementToContain(AccountPage.Selectors.alertMessage, expectedMessage);
        }

        public void UnmanageTestCase(AccountSettings accountSettings)
        {
            UpdateAccountSettings(accountSettings);

            foreach (string accountId in accountSettings.accountIds)
            {
                AccountsPage.GoTo();
                Thread.Sleep(1000);
                SeleniumHelpers.FindElement(AccountsPage.Selectors.accountsGrid);
                AccountsPage.FilterByAccountNumber(accountId);
                SeleniumHelpers.FindElement(AccountsPage.Selectors.inactiveAccountsButton).Click();
                InactiveAccountsPage.WaitForPageToLoad();
                InactiveAccountsPage.VerifyPage();
                InactiveAccountsPage.Exit();
                ClientPage.GoTo(accountSettings.clientId);
                ClientPage.VerifyPage();
            }
        }

        public void MarginAccountTestCase(AccountSettings accountSettings)
        {
            CustodianSettings custodianSettings = new CustodianSettings("FIDELITY");
            custodianSettings.tradeFormat = "Fidelity Block";
            UpdateCustodianSettings(custodianSettings);
            UpdateAccountSettings(accountSettings);
            ModelRebalanceWorkflow workflow = new ModelRebalanceWorkflow(accountSettings.clientId, false);
            workflow.Execute();
        }

        public void TransactionCostsTestCase(AccountSettings accountSettings)
        {
            CustodianSettings custodianSettings = new CustodianSettings("SCHWAB");
            custodianSettings.sellMinimumCost = 500;
            custodianSettings.sellMaximumCost = 10000;
            custodianSettings.buyPercentageCost = 20;
            custodianSettings.sellPercentageCost = 20;
            UpdateCustodianSettings(custodianSettings);
            UpdateAccountSettings(accountSettings);
            ModelRebalanceWorkflow workflow = new ModelRebalanceWorkflow(accountSettings.clientId, false);
            workflow.Execute();
        }

        public void TestCaseNoTrades(AccountSettings accountSettings)
        {
            UpdateAccountSettings(accountSettings);
            ModelRebalanceWorkflow workflow = new ModelRebalanceWorkflow(accountSettings.clientId, false, false);
            workflow.Execute();
        }

        public void TestCase(AccountSettings accountSettings)
        {
            UpdateAccountSettings(accountSettings);
            ModelRebalanceWorkflow workflow = new ModelRebalanceWorkflow(accountSettings.clientId, false);
            workflow.Execute();
        }
    }
}