using System;
using TrxUITest.src.utils.PageData.Elements;

public class NotesPageData : PageData
{
    public TextElement clientNotesCount = new TextElement("#notes-radios > span:nth-child(1) > span");
    public TextElement accountNotesCount = new TextElement("#notes-radios > span:nth-child(2) > span");
    public TextElement reviewNotesCount = new TextElement("#notes-radios > span:nth-child(3) > span");
    public ColumnHeaderElement noteColumnHeader;

    public class ReviewNotesPageData : NotesPageData
    {
        public ReviewNotesPageData()
        {
            noteColumnHeader = new ColumnHeaderElement("#review-notes-grid > div > div.tg-pane-header > div.tg-scrollpane.tg-pane.tg-pane-left.tg-pane-header-left > div > div > div > div.tg-column-item.tg-c-7.tg-h-0 > div > div");
        }

        public ComplexGridElement grid = new ComplexGridElement("#review-wrapper",
            new Type[] { typeof(TextElement), typeof(TextElement), typeof(TextElement), typeof(CurrentTimestampElement), null, typeof(CurrentTimestampElement), null, typeof(TextElement) });
    }

    public class ClientNotesPageData : NotesPageData
    {
        public ClientNotesPageData()
        {
            noteColumnHeader = new ColumnHeaderElement("div.tg-column-item.tg-c-7.tg-h-0");
        }

        public ComplexGridElement grid = new ComplexGridElement("#household-wrapper",
            new Type[] { typeof(TextElement), typeof(TextElement), typeof(TextElement), typeof(CurrentTimestampElement), null, typeof(CurrentTimestampElement), null, typeof(TextElement) });
    }

    public class AccountNotesPageData : NotesPageData
    {
        public AccountNotesPageData()
        {
            noteColumnHeader = new ColumnHeaderElement("div.tg-column-item.tg-c-8.tg-h-0");
        }

        public ComplexGridElement grid = new ComplexGridElement("#account-wrapper",
            new Type[] { typeof(TextElement), typeof(TextElement), typeof(TextElement), typeof(TextElement), typeof(CurrentTimestampElement), null, typeof(CurrentTimestampElement), null, typeof(TextElement) });
    }
}