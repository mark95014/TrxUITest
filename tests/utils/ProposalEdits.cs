using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.utils;

namespace TrxUITest.src.tests.utils
{

    public enum EditAction { enterAmount, toggleSign, balance, takeDiff, tradeLot, sellAll, cancelTrade, none }

    public enum FinishType { save, reset, cancel }

    public class Position
    {
        public string accountNumber;
        public string symbol;

        public Position(String accountNumber, string symbol)
        {
            this.accountNumber = accountNumber;
            this.symbol = symbol;
        }
    }

    public abstract class BalanceAccountBase
    {
        public string account;
        public string subclass;
        public string security;

        public BalanceAccountBase(string account, string security, string subclass = "All SubClasses")
        {
            this.account = account;
            this.security = security;
            this.subclass = subclass;
        }

        public void Edit()
        {
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.unbalancedAccountsPulldown).SendKeys(this.account);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.unbalancedAccountsFirstCheckbox).Click();
            Thread.Sleep(2000);
            SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
            Thread.Sleep(2000);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.subclassPulldown).SendKeys(this.subclass);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.symbolPulldown).SendKeys(this.security);
        }

        public static void ClearSelection()
        {
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.unbalancedAccountsPulldown).SendKeys("<All>");
            Thread.Sleep(1000);
        }

        public void Buy()
        {
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.buySecurityButton).Click();
            Thread.Sleep(2000);
            SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
            Thread.Sleep(2000);
        }
    }

    public class BalanceAccount : BalanceAccountBase
    {
        public new void Edit()
        {
            base.Edit();
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.balanceAccountButton).Click();
            base.Buy();
        }

        BalanceAccount(string account, string security, string subclass = "All Subclasses") : base(account, security, subclass)
        {
        }
    }

    public class BalanceAccountByAmount : BalanceAccountBase
    {
        public string amount;

        public new void Edit()
        {
            base.Edit();
            SeleniumHelpers.ClearField(EditProposalPage.Selectors.buyAmountInput, useXpath: true);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.buyAmountInput, useXpath: true).SendKeys(this.amount);
            base.Buy();
        }

        public BalanceAccountByAmount(string account, string security, string amount, string subclass) : base(account, security, subclass)
        {
            this.amount = amount;
        }
    }

    public abstract class EditClass
    {
        public EditAction action;

        public abstract void Select();
        public abstract void Edit();

        public void ClearSelection()
        {
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.accountsPulldown).SendKeys("<All>");
            SeleniumHelpers.ClearField(EditProposalPage.Selectors.symbol);
        }

        private void SaveChanges()
        {
            if (this.action != EditAction.sellAll && this.action != EditAction.cancelTrade && this.action != EditAction.none)
            {
                SeleniumHelpers.FindElement(EditProposalPage.Selectors.saveEditButton).Click();
                Thread.Sleep(500);
                SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
            }
        }

        public void Process(bool verify)
        {
            Select();
            Thread.Sleep(500);

            if (this.GetType() != typeof(EditAll) && verify)
            {
                Thread.Sleep(1000);
                CommonVerifyPage.Verify(new EditProposalSecurityDetailPageData());
            }

            this.Edit();
            this.SaveChanges();
            this.ClearSelection();
        }

        public void Undo()
        {
            this.Select();
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.undoEditsButton).Click();
            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.confirmUndoEditsButton).Click();
            EditProposalPage.WaitForPageToLoad();
        }

        public EditClass(EditAction action)
        {
            this.action = action;
        }
    }

    public class EditPosition : EditClass
    {
        public Position position;

        public EditPosition(Position position, EditAction action) : base(action)
        {
            this.position = position;
        }

        public override void Select()
        {
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.accountsPulldown).SendKeys(this.position.accountNumber);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.symbol).SendKeys(this.position.symbol);
            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.firstFilteredAccount).Click();

            if (this.action == EditAction.sellAll || this.action == EditAction.cancelTrade)
            {
                SeleniumHelpers.FindElement(EditProposalPage.Selectors.firstCheckbox).Click();
                Thread.Sleep(1000);
            }
            Thread.Sleep(500);
        }

        public override void Edit()
        {
            switch (this.action)
            {
                case EditAction.sellAll:
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.sellAllButton).Click();
                    Thread.Sleep(1000);
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.confirmSellAllButton).Click();
                    SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
                    EditProposalPage.WaitForPageToLoad();
                    break;

                case EditAction.cancelTrade:
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.cancelTradesButton).Click();
                    Thread.Sleep(1000);
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.confirmCancelTradesButton).Click();
                    SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
                    break;


                case EditAction.toggleSign:
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.toggleSignButton).Click();
                    break;

                case EditAction.balance:
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.balanceButton).Click();
                    break;

                case EditAction.takeDiff:
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.takeDiffButton).Click();
                    break;

                case EditAction.none: //Just select the position, but do not edit it
                    break;
            }
        }
    }

    public class EditPositionByAmount : EditPosition
    {
        public string amount;

        public EditPositionByAmount(Position position, string amount) : base(position, EditAction.enterAmount)
        {
            this.amount = amount;
        }

        public override void Edit()
        {
            SeleniumHelpers.ClearField(EditProposalPage.Selectors.editAmount);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.editAmount).SendKeys(this.amount);
        }
    }

    public class EditAll : EditClass
    {

        public EditAll(EditAction action) : base(action)
        {
        }

        //The only two options for editing positions when you select all positions are sell all of each position or cancel each of the trades
        public override void Edit()
        {
            switch (this.action)
            {
                case EditAction.sellAll:
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.sellAllButton).Click();
                    Thread.Sleep(1000);
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.confirmSellAllButton).Click();
                    SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
                    break;

                case EditAction.cancelTrade:
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.cancelTradesButton).Click();
                    Thread.Sleep(1000);
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.confirmCancelTradesButton).Click();
                    SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
                    break;
            }
        }

        public override void Select()
        {
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.selectAllCheckbox).Click();
        }
    }



    public class ProposalEditsClass //??? where is ProposalEdits  (original name) used?
    {
        public string clientId = "";
        public EditClass[] edits = { };
        public FinishType finishType = FinishType.save;
        public bool undo = false;
        public EditByTradeLot[] tradeLotEdits = { };
        public BalanceAccount[] balanceAccounts = { };

        public void Process(bool verify)
        {
            if (this.edits.Length > 0)
            {
                foreach (EditClass edit in this.edits)
                {
                    edit.Process(verify);
                }
            }

            if (this.tradeLotEdits.Length > 0)
            {
                foreach (EditByTradeLot tradeLotEdit in this.tradeLotEdits)
                {
                    tradeLotEdit.Edit();
                    TradeLotModal.Exit();
                }
            }

            if (this.balanceAccounts.Length > 0)
            {
                foreach (BalanceAccount balanceAccount in this.balanceAccounts)
                {
                    balanceAccount.Edit();
                }
                BalanceAccountBase.ClearSelection();
            }

            if (this.undo)
            {
                foreach (EditClass edit in this.edits)
                {
                    edit.Undo();
                }
            }

            if (verify)
            {
                CommonVerifyPage.Verify(new EditProposalPageData());
            }

            this.Finish();
        }

        public void Finish(bool recursion = false)
        { //ways of finishing a proposal edit: save, reset/save, cancel
            switch (this.finishType)
            {
                case FinishType.save:
                    Thread.Sleep(1000);
                    SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
                    Thread.Sleep(1000);

                    IJavaScriptExecutor js = (IJavaScriptExecutor)Test.driver;
                    js.ExecuteScript("window.scrollTo(0, 0);"); //??? make a util method for this
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.saveProposalButton);

                    Thread.Sleep(2000);
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.saveProposalButton).Click();
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.reconcileModalHeader);
                    Thread.Sleep(1000);

                    if (!recursion)
                    {
                        IWebElement element = SeleniumHelpers.FindElement(EditProposalPage.Selectors.numAccountsNotReconciled);
                        if (element.Text != "0")
                        {
                            SeleniumHelpers.FindElement(EditProposalPage.Selectors.reconcileViewButton).Click();
                            SeleniumHelpers.FindElement(EditProposalPage.Selectors.reconcileAddToAccountCashButton).Click();

                            Thread.Sleep(1000);
                            SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
                            Thread.Sleep(1000);

                            SeleniumHelpers.FindElement(EditProposalPage.Selectors.breadCrumbs);

                            this.Finish(true);
                        }
                    }

                    if (!recursion)
                    {
                        Thread.Sleep(1000);
                        SeleniumHelpers.FindElement(EditProposalPage.Selectors.reconcileButton).Click();
                        SeleniumHelpers.FindElement(EditProposalPage.Selectors.confirmReconcileButton).Click();
                        Thread.Sleep(1000);
                    }

                    break;


                case FinishType.cancel:
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.cancelButton);
                    Actions action1 = new Actions(Test.driver);
                    IWebElement cancelButtonElement = SeleniumHelpers.FindElement(EditProposalPage.Selectors.cancelButton);
                    action1.MoveToElement(cancelButtonElement).Perform();
                    cancelButtonElement.Click();
                    break;


                case FinishType.reset: //??? Why is confirmResetButton not clicked?
                    SeleniumHelpers.FindElement(EditProposalPage.Selectors.cancelButton);
                    Actions action2 = new Actions(Test.driver);
                    IWebElement resetButtonElement = SeleniumHelpers.FindElement(EditProposalPage.Selectors.cancelButton);
                    action2.MoveToElement(resetButtonElement).Perform();
                    resetButtonElement.Click();
                    //SeleniumHelpers.FindElement(EditProposalPage.Selectors.confirmResetButton).Click();
                    EditProposalPage.WaitForPageToLoad();
                    EditProposalPage.VerifyPage();
                    break;
            }
        }
    }

    public class TradeLotModal
    {
        public static void Exit()
        {
            Thread.Sleep(2000);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.tradeLotExitButton).Click();
            Thread.Sleep(2000);
            SeleniumHelpers.WaitForElementToDisappear(EditProposalPage.Selectors.spinner);
            Thread.Sleep(2000);
        }
    }

    public abstract class EditByTradeLot : EditPosition
    {
        public string shares;

        public override void Edit()
        {
            base.Select();
            CommonVerifyPage.Verify(new EditProposalSecurityDetailPageData());
            base.ClearSelection();
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.tradeLotsButton).Click();
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.tradeLotTitle);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.tradeLotShares).SendKeys(this.shares);

            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.tradeLotLotNumber).Click();
            Thread.Sleep(1000);
        }

        public EditByTradeLot(Position position, string shares) : base(position, EditAction.tradeLot)
        {
            this.shares = shares;
        }
    }

    public class EditByTradeLotSellAmount : EditByTradeLot
    {
        public string amount;

        public override void Edit()
        {
            base.Edit();
            SeleniumHelpers.ClearField(EditProposalPage.Selectors.tradeLotSellAmount).SendKeys(this.amount);
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.tradeLotSellButton).Click();
            base.ClearSelection();
            Thread.Sleep(1000);
        }

        public EditByTradeLotSellAmount(Position position, string shares, string amount) : base(position, shares)
        {
            this.amount = amount;
        }
    }

    public class EditByTradeLotSellAll : EditByTradeLot
    {
        public override void Edit()
        {
            base.Edit();
            SeleniumHelpers.FindElement(EditProposalPage.Selectors.tradeLotSellAllButton).Click();
        }

        public EditByTradeLotSellAll(Position position, string shares) : base(position, shares)
        {
        }
    }
}