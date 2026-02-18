using System.Collections.Generic;

namespace TrxUITest.src.tests.utils
{
    public class Buy(string subClass, string symbol, string percent)
    {
        public string subClass = subClass;
        public string symbol = symbol;
        public string percent = percent;
    }

    public class TradeType
    {
        public enum TradeTypes {PercentOfPosition, ToTargetPercent, ByPercentOfClient, Amount};

        public static Dictionary<TradeTypes, string> types = new Dictionary<TradeTypes, string>();
        public TradeType()
        {
            types[TradeTypes.PercentOfPosition] = "Percent of Position";
            types[TradeTypes.ToTargetPercent] = "To Target Percent";
            types[TradeTypes.ByPercentOfClient] = "By Percent of Client";
            types[TradeTypes.Amount] = "Amount";
        }
    }

    public class Sell
    {
        public TradeType.TradeTypes tradeType;
        public string amount;

        public Sell(TradeType.TradeTypes tradeType, string amount)
        {
            this.tradeType = tradeType;
            this.amount = amount;
        }
    }

    public class Filter
    {
        public string subClass;
        public string symbol;
        public string[] accounts;
        public string value;
        public string advisorSet;

        public Filter(string subClass, string symbol, string[] accounts = null, string value = null, string advisorSet = null)
        {
            this.subClass = subClass;
            this.symbol = symbol;
            this.accounts = accounts;
            this.value = value;
            this.advisorSet = advisorSet;
        }
    }

    public class TacticalTrade
    {
        public Filter filter;
        public Sell sell;
        public Buy[] buys;

        public TacticalTrade(Filter filter, Sell sell, Buy[] buys)
        {
            this.filter = filter;
            this.sell = sell;
            this.buys = buys;
        }
    }
}