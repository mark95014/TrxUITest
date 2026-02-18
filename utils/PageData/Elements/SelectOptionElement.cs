using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TrxUITest.src.utils.PageData.Elements
{
    public class SelectOptionElement : SimpleElement
    {
        public SelectOptionElement(string selector) : base(selector)
        {
        }

        public override void Get()
        {
            SelectElement dropdown = new SelectElement(Test.driver.FindElement(By.CssSelector(this.selector)));
            data = dropdown.SelectedOption.GetAttribute("value");
        }

        public override void GetByWebElement(IWebElement webElement)
        {
            data = webElement.Text;//??? does this need to use a SelectElement also?
        }
    }
}