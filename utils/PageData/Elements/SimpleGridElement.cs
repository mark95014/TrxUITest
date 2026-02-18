using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TrxUITest.src.utils.PageData.Elements
{
    public class SimpleGridElement : GridElement
    {
        public SimpleGridElement(string selector = "") : base(selector) { }

        public override Result VerifyCell(Object actualResult, Object expectedResult, string msg, int colnumber) {
            Result result = new Result (actualResult.ToString().Equals(expectedResult.ToString()), msg);
            return result;
        }

        public override void GetCell(IWebElement element, List<Object> row, int columnNumber)
        {
            row.Add(element.Text);
        }
    }
}