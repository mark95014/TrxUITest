namespace TrxUITest.src.tests.utils
{
    public class LimitOrder
    {
        public string symbol;
        public string duration;
        public string price;

      public LimitOrder(string symbol, string duration, string price)
        {
            this.symbol = symbol;
            this.duration = duration;
            this.price = price;
      }
    }
}
