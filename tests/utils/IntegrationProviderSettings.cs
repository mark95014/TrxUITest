namespace TrxUITest.src.tests.utils
{
    public class IntegrationProviderSettings
    {
        public string providerName;
        public string user;
        public string password;

        public IntegrationProviderSettings(string providerName, string user, string password)
        {
            this.providerName = providerName;
            this.user = user;
            this.password = password;
        }
    }
}
