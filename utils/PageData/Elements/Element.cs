using Newtonsoft.Json;
using OpenQA.Selenium;
using System;

namespace TrxUITest.src.utils.PageData.Elements
{
    public abstract class Element
    {
        public Object data;

        [JsonIgnore]
        public string selector;

        public Element(string selector = "")
        {
            this.selector = selector;
        }

        public abstract void Get();

        public abstract void GetByWebElement(IWebElement webElement);

        public abstract Result Verify(string name, Object expected);
    }
}