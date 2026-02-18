using TrxUITest.src.utils.PageData.Elements;

namespace TrxUITest.src.pages
{
    internal class TlhCompliancePageData : PageData
    {
       public TextElement title = new TextElement("#bread-crumb-title");
       public TextElement clientId = new TextElement("#household-number");
       public TextElement model = new TextElement("#model-desc");
       public TextElement summary = new TextElement("#tlh-amounts-wrapper > div:nth-child(1) > h4");
       public TextElement total = new TextElement("#tlh-amounts-wrapper > div:nth-child(2) > h4");
       public TextElement harvest = new TextElement("#tlh-amounts-wrapper > div:nth-child(3) > h4");
       public TextElement positionMinimum = new TextElement("#tlh-amounts-wrapper > div:nth-child(4) > h4");
       public TextElement tradeLotMinimum = new TextElement("#tlh-amounts-wrapper > div:nth-child(5) > h4");
       public ElementAttribute createProposalButton = new ElementAttribute("#tlh-proposal-btn","disabled");
       public SimpleGridElement tlhGrid = new SimpleGridElement("#vue-route > div > div.container.main-container > div:nth-child(4)");
    }
}