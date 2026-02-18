using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TrxUITest.src.utils.PageData.Elements
{
    public class ElementAttribute : SimpleElement
    {

        public string attributeSelector;

        public ElementAttribute (string selector, string attributeSelector) : base(selector)
        {
            this.attributeSelector = attributeSelector;
        }

        public override void Get() 
        {
            data = Test.driver.FindElement(By.CssSelector(this.selector)).GetAttribute(this.attributeSelector);
            if (data == null) data = "false";
        }

        public override void GetByWebElement(IWebElement element) {
            data = element.GetAttribute(this.attributeSelector);
        }
    }
}