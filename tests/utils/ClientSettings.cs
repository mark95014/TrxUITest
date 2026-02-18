namespace TrxUITest.src.tests
{
    public class ClientSettings
    {
        public string advisorSet;
        public string rebalanceSet;
        public string preferredBuySet;
        public string model;
        public string status;

        public ClientSettings(string advisorSet, string rebalanceSet, string preferredBuyset, string model, string status)
        {
            this.advisorSet = advisorSet;
            this.rebalanceSet = rebalanceSet;
            this.preferredBuySet = preferredBuyset;
            this.model = model;
            this.status = status;
        }
    }
}