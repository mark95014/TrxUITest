namespace TrxUITest.src.tests.utils
{
    public class AccountSettings
    {
        public string[] accountIds;
        public string clientId;
        public string model;
        public string category;
        public bool? billingAccount;
        public bool? managedAccount;
        public bool? marginAccount;
        public string marginPercent;
        public string dividendReinvestment;
        public string buyTransactionCosts;
        public string sellTransactionCosts;
        public string masterAccount;
        public bool? restrictedAccount;
        public string restrictedPlan;
        public bool? smaAccount;
        public SMAAllocation[] smaAllocations;
        public string minimumCash;
        public string maximumCash;
        public string cashType;
        public string cashGoal;
        public string minimumTransactionDollars;
        public string minimumTransactionPercent;
        public string minimumTransactionFlag;
        public string mutualFundRounding;
        public string rmdMinimum;
        public string rmdMaximum;
        public string otherMinimum;
        public string otherMaximum;
        public string cashSetasideGoal;


    //model: you can change the model for an account. It will create a new client for that account using the account description as the client name.
    //If a client with that name already exists, it will not let you change the model on the account.
    public AccountSettings(string[] accountIds, string clientId)
        {
            this.accountIds = accountIds;
            this.clientId = clientId;
            this.cashSetasideGoal = null;
            this.model = null;
            this.category = null;
            this.billingAccount = null;
            this.managedAccount = null;
            this.marginAccount = null;
            this.marginPercent = null;
            this.dividendReinvestment = null;
            this.buyTransactionCosts = null;
            this.sellTransactionCosts = null;
            this.masterAccount = null;
            this.restrictedAccount = null;
            this.restrictedPlan = null;
            this.smaAccount = null;
            this.smaAllocations = null;
            this.minimumCash = null;
            this.maximumCash = null;
            this.cashType = null;
            this.cashGoal = null;
            this.minimumTransactionDollars = null;
            this.minimumTransactionPercent = null;
            this.minimumTransactionFlag = null;
            this.mutualFundRounding = null;
            this.rmdMinimum = null;
            this.rmdMaximum = null;
            this.otherMinimum = null;
            this.otherMaximum = null;
            this.cashSetasideGoal = null;
        }
    }
}
