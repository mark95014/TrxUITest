using OpenQA.Selenium;
using TrxUITest.src.utils;
using TrxUITest.src.tests.utils;
using System.Collections.ObjectModel;

namespace TrxUITest.src.pages
{
    public static class AccountPage
    {
        public static class Selectors
        {
            readonly public static string spinner = "#edge > div > div > div.loader-overlay > div > div";
            readonly public static string saveButton = "#save-changes-btn";
            readonly public static string clientDetailsButton = "#client-details-btn";
            readonly public static string substitutionsButton = "#substitutions-btn";
            readonly public static string positionsButton = "#positions-btn";
            readonly public static string applyModelButton = "#apply-model-btn";
            readonly public static string restrictedPlanSelect = "#restrictedPlan-select";
            readonly public static string restrictedPlanSaveButton = "#save-add";
            readonly public static string smaTitle = "#sma-modal > div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > h2 > span";
            readonly public static string smaAddButton = "#add-edit-rplan-add-btn";
            readonly public static string smaSaveButton = "#add-edit-rplan-save-btn";
            readonly public static string smaSubclassSelect = "#sma-modal #select-subclass.mds-select__input_trx";
            readonly public static string smaSubclassPercent = "#sma-modal input";
            readonly public static string alertMessage = "#vue-route > div > div:nth-child(3) > div > div:nth-child(1) > div > div > div.mds-alert__body_trx > div > p";
        }

        readonly public static string pageUrl = "app.aspx#/accountDetail";

        public static void GoTo(string accountNumber)
        {
            AccountsPage.GoTo();
            AccountsPage.WaitForPageToLoad();
            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(AccountsPage.Selectors.accountsGrid);
            AccountsPage.FilterByAccountNumber(accountNumber);
            IWebElement firstAccountElement = SeleniumHelpers.FindElement(AccountsPage.Selectors.firstAccount);
            firstAccountElement.Click();
            WaitForPageToLoad();
        }

        public static void WaitForPageToLoad()
        {
            Thread.Sleep(2000);
            AccountPageData accountPageData = new AccountPageData();
            SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            SeleniumHelpers.WaitForElementToContain(accountPageData.title.selector, "Account Details");
            SeleniumHelpers.FindElement(accountPageData.totalCash.selector);
            SeleniumHelpers.FindElement(accountPageData.cashSetasideGoal.selector);
            SeleniumHelpers.FindElement(Selectors.clientDetailsButton);
            SeleniumHelpers.FindElement(Selectors.positionsButton);
            SeleniumHelpers.FindElement(Selectors.substitutionsButton);
            Thread.Sleep(1000);
        }

        public static void VerifyPage()
        {
            CommonVerifyPage.Verify(new AccountPageData());
        }

        //??? Revisit this when something uses it
        public static void Update(AccountSettings accountSettings)
        {
            WaitForPageToLoad();
            AccountPageData accountPageData = new AccountPageData();

            if (accountSettings != null)
            {
                if (accountSettings.model != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.model.selector).SendKeys(accountSettings.model);
                    Thread.Sleep(1000);
                    Test.driver.SwitchTo().Alert().Accept();
                    Thread.Sleep(1000);
                    SeleniumHelpers.FindElement(Selectors.applyModelButton).Click();
                }

                if (accountSettings.category != null) SeleniumHelpers.FindElement(accountPageData.category.selector).SendKeys(accountSettings.category);
                if (accountSettings.billingAccount.HasValue) if ((bool)accountSettings.billingAccount) accountPageData.billingAccount.Check(); else accountPageData.billingAccount.UnCheck();
                if (accountSettings.managedAccount.HasValue) if ((bool)accountSettings.managedAccount) accountPageData.managedAccount.Check(); else accountPageData.managedAccount.UnCheck();
                if (accountSettings.marginAccount.HasValue) if ((bool)accountSettings.marginAccount) accountPageData.marginAccount.Check(); else accountPageData.marginAccount.UnCheck();
 
                if (accountSettings.marginPercent != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.marginPercent.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.marginPercent.selector).SendKeys(accountSettings.marginPercent);
                }

                if (accountSettings.dividendReinvestment != null) SeleniumHelpers.FindElement(accountPageData.dividendReinvestment.selector).SendKeys(accountSettings.dividendReinvestment);
                if (accountSettings.buyTransactionCosts != null) SeleniumHelpers.FindElement(accountPageData.buyTransactionCosts.selector).SendKeys(accountSettings.buyTransactionCosts);
                if (accountSettings.sellTransactionCosts != null) SeleniumHelpers.FindElement(accountPageData.sellTransactionCosts.selector).SendKeys(accountSettings.sellTransactionCosts);

                if (accountSettings.masterAccount != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.masterAccount.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.masterAccount.selector).SendKeys(accountSettings.masterAccount);
                }

                if (accountSettings.restrictedAccount.HasValue)
                {
                    if ((bool)accountSettings.restrictedAccount) accountPageData.restrictedAccount.Check(); else accountPageData.restrictedAccount.UnCheck();
                    Thread.Sleep(2000);
                    SeleniumHelpers.SelectOptionByText(Selectors.restrictedPlanSelect, accountSettings.restrictedPlan);
                    Thread.Sleep(2000);
                    SeleniumHelpers.FindElement(Selectors.restrictedPlanSaveButton).Click();
                    Thread.Sleep(2000);
                }

                if (accountSettings.smaAccount.HasValue)
                {
                    if ((bool)accountSettings.smaAccount) accountPageData.smaAccount.Check(); else accountPageData.smaAccount.UnCheck();
                    SeleniumHelpers.FindElement(Selectors.smaTitle);

                    foreach (SMAAllocation allocation in accountSettings.smaAllocations)
                    {
                        //Thread.Sleep(5000);
                        SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
                        SeleniumHelpers.FindElement(Selectors.smaAddButton).Click();
                        ReadOnlyCollection<IWebElement> subclassSelectElements = Test.driver.FindElements(By.CssSelector(Selectors.smaSubclassSelect));
                        int index = subclassSelectElements.Count - 1;
                        subclassSelectElements[index].SendKeys(allocation.subclass);

                        ReadOnlyCollection<IWebElement> subclassPercentageElements = Test.driver.FindElements(By.CssSelector(Selectors.smaSubclassPercent));
                        index = subclassPercentageElements.Count - 1;
                        subclassPercentageElements[index].SendKeys(allocation.percentage);
                    }

                    SeleniumHelpers.FindElement(Selectors.smaSaveButton).Click();
                    Thread.Sleep(5000);
                    SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
                }

                if (accountSettings.minimumCash != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.minimumCash.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.minimumCash.selector).SendKeys(accountSettings.minimumCash);
                }

                if (accountSettings.maximumCash != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.maximumCash.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.maximumCash.selector).SendKeys(accountSettings.maximumCash);
                }

                if (accountSettings.cashType != null) SeleniumHelpers.FindElement(accountPageData.cashType.selector).SendKeys(accountSettings.cashType);
                if (accountSettings.cashGoal != null) SeleniumHelpers.FindElement(accountPageData.cashGoal.selector).SendKeys(accountSettings.cashGoal);

                if (accountSettings.minimumTransactionDollars != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.minimumTransactionDollars.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.minimumTransactionDollars.selector).SendKeys(accountSettings.minimumTransactionDollars);
                }

                if (accountSettings.minimumTransactionPercent != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.minimumTransactionPercent.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.minimumTransactionPercent.selector).SendKeys(accountSettings.minimumTransactionPercent);
                }

                if (accountSettings.minimumTransactionFlag != null) SeleniumHelpers.FindElement(accountPageData.minimumTransactionFlag.selector).SendKeys(accountSettings.minimumTransactionFlag);
                if (accountSettings.mutualFundRounding != null) SeleniumHelpers.FindElement(accountPageData.mutualFundRounding.selector).SendKeys(accountSettings.mutualFundRounding);

                if (accountSettings.rmdMinimum != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.rmdMinimum.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.rmdMinimum.selector).SendKeys(accountSettings.rmdMinimum);
                }

                if (accountSettings.rmdMaximum != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.rmdMaximum.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.rmdMaximum.selector).SendKeys(accountSettings.rmdMaximum);
                }

                if (accountSettings.otherMinimum != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.otherMinimum.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.otherMinimum.selector).SendKeys(accountSettings.otherMinimum);
                }

                if (accountSettings.otherMaximum != null)
                {
                    SeleniumHelpers.FindElement(accountPageData.otherMaximum.selector).Clear();
                    SeleniumHelpers.FindElement(accountPageData.otherMaximum.selector).SendKeys(accountSettings.otherMaximum);
                }

                if (accountSettings.cashSetasideGoal != null) SeleniumHelpers.FindElement(accountPageData.cashSetasideGoal.selector).SendKeys(accountSettings.cashSetasideGoal);

                Thread.Sleep(1000);
                SeleniumHelpers.FindElement(Selectors.saveButton);
                JavaScriptExec.Click(Selectors.saveButton);
                Thread.Sleep(2000);
                SeleniumHelpers.WaitForElementToDisappear(Selectors.spinner);
            }
        }
    }
}
