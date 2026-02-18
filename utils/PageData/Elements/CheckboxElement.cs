using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData.Elements;

public class CheckboxElement : SimpleElement
{

    public CheckboxElement(string selector) : base(selector)
    {
    }

    public void Check()
    {
        IWebElement checkboxElement = SeleniumHelpers.FindElement(selector);

        if (!checkboxElement.Selected)
        {
            //checkboxElement.Click();
            JavaScriptExec.Click(selector);
        }
    }

    public void UnCheck()
    {
        IWebElement checkboxElement = SeleniumHelpers.FindElement(selector);

        if (checkboxElement.Selected)
        {
            //checkboxElement.Click();
            JavaScriptExec.Click(selector);
        }
    }

    public override void Get()
    {
        IWebElement checkboxElement = SeleniumHelpers.FindElement(selector);
        string checkedAttribute = checkboxElement.GetAttribute("checked");
        data = checkedAttribute != null && checkedAttribute.Equals("true");
    }

    public override void GetByWebElement(IWebElement element)
    {
        data = element.GetAttribute("checked");
    }

    public override Result Verify(string name, object expected)
    {
        var message = name + ": " + "actual=" + data.ToString() + " expected=" + expected.ToString();

        bool actualValue = (bool)data;

        bool expectedValue = (bool) ((JValue)expected).Value;

        return new Result ((actualValue == expectedValue), message);
    }
}