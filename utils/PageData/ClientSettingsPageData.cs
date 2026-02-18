using TrxUITest.src.utils.PageData.Elements;

public class ClientSettingsPageData : PageData
{
    public TextElement title = new TextElement("#manage-hh-settings-modal h2 > span");
    public ValueElement advisor  = new ValueElement("#manage-hh-select-advisor");
    public ValueElement rebalanceSet  = new ValueElement("#manage-hh-select-rebalset");
    public ValueElement buySet  = new ValueElement("#manage-hh-select-buyset");
    public ValueElement model  = new ValueElement("#manage-hh-select-model");
    public ValueElement status  = new ValueElement("#manage-hh-select-status");
}