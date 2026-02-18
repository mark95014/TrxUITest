using TrxUITest;
using TrxUITest.src.utils.PageData.Elements;

public class FlyerPageData : PageData
{

    public TextElement breadCrumbs = new TextElement("#bread-crumb-title");

    //Warning: the response from Flyer"s "TEST" system is unpredictable. These values may not always be correct, so I commented them out.
    //Only the json file will be verified.
    //public ValueElement enrollment = new ValueElement("#direct-trades-providers-select");
    //public TextElement clientCount = new TextElement("#vue-route > div > form > div:nth-child(3) > div:nth-child(3) > div > div:nth-child(3) > div:nth-child(2) > h4");
    //public TextElement accountsCount = new TextElement("#vue-route > div > form > div:nth-child(3) > div:nth-child(3) > div > div:nth-child(3) > div:nth-child(3) > h4");
    //public TextElement totalTradesCount = new TextElement("#vue-route > div > form > div:nth-child(3) > div:nth-child(3) > div > div:nth-child(3) > div:nth-child(4) > h4");
    //public TextElement submittedTradesCount = new TextElement("#vue-route > div > form > div:nth-child(3) > div:nth-child(3) > div > div:nth-child(3) > div:nth-child(5) > h4");
    //public TextElement executedTradesCount = new TextElement("#vue-route > div > form > div:nth-child(3) > div:nth-child(3) > div > div:nth-child(3) > div:nth-child(6) > h4");
    //public CsvElement grid = new CsvElement("#downcsv-fixSubmitGrid-action-bar-top > span", "fix-submissions.csv", new string[] { "* 0", "* 10" }); //ignore status and submit date. status is inconsistent.

    //Sometimes, the uatfileshare is not accessible, so you have to deactivate the jsonFiles element if that occurs.
    //public FlyerJsonFilesElement jsonFiles = new FlyerJsonFilesElement();
}