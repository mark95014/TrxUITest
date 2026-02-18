using TrxUITest.src.utils.PageData.Elements;

class IntegrationProviderSettingsPageData: PageData
{
    public ValueElement menu = new ValueElement("#enterprise-menu-btn");
    public ValueElement providerSelect = new ValueElement("#trading-options-providers-select");
    public ValueElement userName = new ValueElement("#trading-options-username-input");
    public ValueElement password = new ValueElement("#trading-options-password-input");
}