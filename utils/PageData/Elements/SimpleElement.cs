using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;

namespace TrxUITest.src.utils.PageData.Elements
{
    public abstract class SimpleElement : Element
    {
        public SimpleElement(string selector) : base(selector) { }

        public override abstract void GetByWebElement(IWebElement element);

        public override Result Verify(string name, Object expected)
        {
            var message = name + ": " + "actual=" + data + " expected=" + expected.ToString();
            Result result = new Result (data.Equals(expected.ToString()), message);
            return result;
        }
    }
}