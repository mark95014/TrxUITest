using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData.Elements;

public class CurrentTimestampElement : Element
{
    public CurrentTimestampElement(string selector) : base(selector)
    {
    }

    public override void Get()
    {
        data = Test.driver.FindElement(By.CssSelector(selector)).Text;
    }

    public override void GetByWebElement(IWebElement webElement)
    {
        data = webElement.Text;
    }

    public override Result Verify(string name, Object expected)
    {
        DateTime discard;
        string dateTime = data.ToString();

        if (DateTime.TryParse(dateTime, out discard) == true)
            return new Result (true, $"{dateTime} is a valid date/time");
        else
            return new Result (false, $"{dateTime} is an invalid date/time");
    }
}