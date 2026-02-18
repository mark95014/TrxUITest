namespace TrxUITest.src.tests
{
    public class TradingOverrideSettings
    {
        public string clientId;
        public string sellFlag;
        public string buyFlag;
        public string symbol;

        public TradingOverrideSettings(string clientId, string symbol, string buyFlag = null, string sellFlag = null)
        {
            this.clientId = clientId;
            this.symbol = symbol;
            this.sellFlag = sellFlag;
            this.buyFlag = buyFlag;
        }
    }
}