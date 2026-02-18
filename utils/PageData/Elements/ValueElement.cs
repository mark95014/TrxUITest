using OpenQA.Selenium;

namespace TrxUITest.src.utils.PageData.Elements
{
    public class ValueElement : SimpleElement
    {
        public ValueElement(string selector) : base(selector)
        {
        }

        public override void Get()
        {
            IWebElement option = Test.driver.FindElement(By.CssSelector(this.selector));
            data = option.GetAttribute("value");
        }

        public override void GetByWebElement(IWebElement webElement)
        {
            data = webElement.Text;
        }
    }
}