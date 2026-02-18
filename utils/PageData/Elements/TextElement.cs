using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace TrxUITest.src.utils.PageData.Elements
{
    public class TextElement : SimpleElement
    {
        readonly TextModifiers modifiers = null;

        public class TextModifiers
        {
            readonly public int? start = null;
            readonly public int? length = null;
            readonly public string regex = null;

            public TextModifiers(int start, int length)
            {
                this.start = start;
                this.length = length;
                this.regex = null;
            }

            public TextModifiers(string regex = null)
            {
                this.regex = regex;
            }
        }

        public TextElement(string selector, TextModifiers modifiers = null) : base(selector)
        {
            this.modifiers = modifiers;
        }

        public TextElement(string selector) : base(selector)
        {
        }

        public override void Get()
        {
            string rawValue = Test.driver.FindElement(By.CssSelector(selector)).Text;

            if (modifiers?.start != null && modifiers.length != null)
            {
                data = rawValue.Substring((int)modifiers.start, (int)(modifiers.start + modifiers.length));

            }
            else
            {
                data = rawValue;
            }
        }

        public override void GetByWebElement(IWebElement webElement)
        {
            data = webElement.Text;
        }

        public override Result Verify(string name, Object expected)
        {
            var message = name + ": " + "actual=" + data + " expected=" + expected.ToString();

            if (modifiers != null && modifiers.regex != null)
            {
                string datastr = data?.ToString()?.Trim() ?? "";
                Regex regex = new Regex(modifiers.regex);
                return new Result (regex.IsMatch(datastr), message);
            }
            else
            {
                return new Result (data.Equals(expected.ToString()), message);
            }
        }
    }
}