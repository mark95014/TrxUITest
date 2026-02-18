namespace TrxUITest.src.tests.utils
{
    public class CustodianSettings
    {
        public string name;
        public string tradeFormat;
        public RedemptionFeePenaltyInterval? costApproach;
        public int? penaltyPercent;
        public int? penaltyIntervalDays;
        public string securityType;
        public int? sellMinimumCost;
        public int? sellMaximumCost;
        public int? sellPercentageCost;
        public string sellCostApproach;
        public int? buyMinimumCost;
        public int? buyMaximumCost;
        public int? buyPercentageCost;
        public string buyCostApproach;
        public string masterAccount;

        public CustodianSettings(string name)
        {
            this.name = name;
            this.tradeFormat = null;
            this.costApproach = null;
            this.penaltyIntervalDays = null;
            this.penaltyPercent = null;
            this.penaltyIntervalDays = null;
            this.securityType = null;
            this.sellMinimumCost = null;
            this.sellMaximumCost = null;
            this.sellPercentageCost = null;
            this.sellCostApproach = null;
            this.buyMinimumCost = null;
            this.buyMaximumCost = null;
            this.buyPercentageCost = null;
            this.buyCostApproach = null;
            this.masterAccount = null;
        }
    }
}