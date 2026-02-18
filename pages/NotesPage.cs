using OpenQA.Selenium;
using System;
using System.Threading;
using TrxUITest.src.utils;
using static TrxUITest.src.tests.utils.Note;

namespace TrxUITest.src.pages
{
    public class NotesPage
    {
        public static class Selectors
        {
            public static readonly string refreshButton = "*[id*=grid-refresh]";
            public static readonly string reviewRefreshButton = "#grid-refresh-review-notes-grid-action-bar-top > span";
            public static readonly string clientButton = "#notes-radios > spannth-child(1) > label > span > span.mds-form__radio-button-visual";
            public static readonly string accountButton = "#notes-radios > spannth-child(2) > label > span > span.mds-form__radio-button-visual";
            public static readonly string reviewButton = "#notes-radios > spannth-child(3) > label > span > span.mds-form__radio-button-visual";
            public static readonly string addButton = "#add-note-btn";
            public static readonly string noteText = "textarea";
            public static readonly string saveButton = "#save-add-note";
            public static readonly string exitButton = " div > div > section > div.mds-section__header-container_trx.mds-section--border-bottom_trx.mds-section--primary_trx.mds-section--font-bold_trx.mds-section--level-5_trx > div > div > button > span > svg > path";
            public static readonly string tradeProposalsExitButton = "#trade-prop-notes-modal button > span > svg";
            public static readonly string noteFilter = "*[id*=notes-grid-filter-NoteText]";
            public static readonly string noteColumnHeader = "div.tg-column-item.tg-c-7.tg-h-0 > div > div";
            public static readonly string deleteButton = "div.tg-cell.tg-c-1.tg-level-0.tg-align-center > button";
            public static readonly string editButton = "div.tg-cell.tg-c-0.tg-level-0.tg-align-center.tg-list-first > button";
            public static readonly string confirmButton = "#notes-modal > div > div > section > div.mds-section__content_trx > div > divnth-child(2) > span > div > button.mds-button_trx.mds-button--primary_trx.mds-button--small_trx > span";
            public static readonly string reviewConfirmButton = "#trade-prop-notes-modal > div > div > section > div.mds-section__content_trx > div > divnth-child(2) > span > div > button.mds-button_trx.mds-button--primary_trx.mds-button--small_trx > span";
            public static readonly string processingSpinner  = "#notes-process-spinner > div > div > div > div > div";
        }

        public static void WaitForPageToLoad()
        {
            SeleniumHelpers.FindElement(new NotesPageData().clientNotesCount.selector);
            Thread.Sleep(2000);
        }

        private static void WaitForProcessingSpinner()
        {
            SeleniumHelpers.WaitForElementToDisappear(Selectors.processingSpinner);
        }

        public static void VerifyPage(NoteType noteType)
        {
            NotesPageData data;

            switch (noteType)
            {
                case NoteType.client:
                    data = new NotesPageData.ClientNotesPageData();
                    break;
                case NoteType.account:
                    data = new NotesPageData.AccountNotesPageData();
                    break;
                case NoteType.review:
                    data = new NotesPageData.ReviewNotesPageData();
                    break;
                default:
                    data = new NotesPageData.ClientNotesPageData();
                    break;
            }

            SeleniumHelpers.FindElement(data.noteColumnHeader.selector).Click();
            CommonVerifyPage.Verify(new NotesPageData());
        }

        private static void Confirm(NoteType noteType)
        { //generic selector does not work on trade proposal review page
            string confirmButtonSelector;

            switch (noteType)
            {
                case NoteType.review:
                    confirmButtonSelector = Selectors.reviewConfirmButton;
                    break;

                default:
                    confirmButtonSelector = Selectors.confirmButton;
                    break;
            }

            IWebElement buttonElement = SeleniumHelpers.FindElement(confirmButtonSelector);
            Thread.Sleep(2000);
            buttonElement.Click();
        }

        private static void Refresh(NoteType noteType)
        { //generic selector does not work on trade proposal review page
            string refreshButtonSelector;

            switch (noteType)
            {
                case NoteType.review:
                    refreshButtonSelector = Selectors.reviewRefreshButton;
                    break;

                default:
                    refreshButtonSelector = Selectors.refreshButton;
                    break;
            }

            IWebElement buttonElement = SeleniumHelpers.FindElement(refreshButtonSelector);
            Thread.Sleep(2000);
            buttonElement.Click();
        }

        public static void Add(string noteText)
        {
            IWebElement buttonElement = SeleniumHelpers.FindElement(Selectors.addButton);
            SeleniumHelpers.WaitForElementToBeVisible(Selectors.addButton);
            Thread.Sleep(2000);
            buttonElement.Click();
            IWebElement noteElement = SeleniumHelpers.FindElement(Selectors.noteText);
            noteElement.SendKeys(noteText);
            Thread.Sleep(2000);
            IWebElement saveButtonElement = SeleniumHelpers.FindElement(Selectors.saveButton);
            SeleniumHelpers.WaitForElementToBeVisible(Selectors.saveButton);
            Thread.Sleep(2000);
            saveButtonElement.Click();
            WaitForProcessingSpinner();
        }

        public static void Edit(string noteText, NoteType noteType)
        {
            SeleniumHelpers.FindElement(Selectors.noteFilter).SendKeys(noteText);
            IWebElement editButtonElement = SeleniumHelpers.FindElement(Selectors.editButton);
            Thread.Sleep(2000);
            editButtonElement.Click();

            string editedText = "edited: " + noteText;
            SeleniumHelpers.FindElement(Selectors.noteText).Clear();
            SeleniumHelpers.FindElement(Selectors.noteText).SendKeys(editedText);
            SeleniumHelpers.FindElement(Selectors.saveButton);
            Thread.Sleep(2000);
            SeleniumHelpers.FindElement(Selectors.saveButton).Click();
            WaitForProcessingSpinner();
        
            SeleniumHelpers.FindElement(Selectors.noteFilter).Clear();
            Refresh(noteType);
        }

        public static void Delete(string noteText, NoteType noteType)
        {
            SeleniumHelpers.FindElement(Selectors.noteFilter);
            Thread.Sleep(4000);
            SeleniumHelpers.FindElement(Selectors.noteFilter).Clear();
            Thread.Sleep(4000);
            SeleniumHelpers.FindElement(Selectors.noteFilter).SendKeys(noteText);
            SeleniumHelpers.FindElement(Selectors.deleteButton).Click();
            Confirm(noteType);
            WaitForProcessingSpinner();
            Thread.Sleep(1000);
            SeleniumHelpers.FindElement(Selectors.noteFilter).Clear();
            Refresh(noteType);
        }

        public static void Exit()
        {
            SeleniumHelpers.FindElement(Selectors.exitButton).Click();
        }
    }
}