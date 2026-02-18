using TrxUITest.src.utils.PageData.Elements;


public class InactiveAccountsPageData: PageData
{
    public TextElement title = new TextElement("#inactive-accounts-modal-header");
    public SimpleGridElement grid = new SimpleGridElement("#inactiveAccountsGrid");
}