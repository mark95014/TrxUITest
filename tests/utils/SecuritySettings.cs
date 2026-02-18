namespace TrxUITest.src.tests
{
    public class SecuritySettings
    {
        readonly public SellFlag sellFlag;
        readonly public string symbol;
        readonly public int? redemptionFeePenaltyPercent;
        readonly public int? redemptionFeePenaltyDays;
        readonly public RedemptionFeePenaltyInterval? redemptionFeePenaltyInterval;

        public SecuritySettings(string symbol, SellFlag sellFlag, int? penaltyPercent = null, int? penaltyDays = null, RedemptionFeePenaltyInterval? interval = null)
        {
            this.symbol = symbol;
            this.sellFlag = sellFlag;
            this.redemptionFeePenaltyPercent = penaltyPercent;
            this.redemptionFeePenaltyDays = penaltyDays;
            this.redemptionFeePenaltyInterval = interval;
        }
    }
}