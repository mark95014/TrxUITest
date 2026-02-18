using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using TrxUITest.src.utils;
using TrxUITest.src.utils.PageData.Elements;


public class ComplexGridElement : GridElement
{
    [JsonIgnore]
    public Type[] columnTypes;

    public ComplexGridElement(string selector, Type[] columnTypes) :base(selector)
    {
        this.columnTypes = columnTypes;
    }

    //The CSS selector of each cell in a grid is unknown, because the selectors are dynamically created.
    //Therefore, we get the data from the cells using an IWebElement. Then we add it to the row of data being collected.
    public override void GetCell(IWebElement webElement, List<Object> row, int columnNumber)
    {
        Type[] types = new Type[1];
        types[0] = typeof(string);
        Type type = columnTypes[columnNumber];

        if (type != null)
        {
            ConstructorInfo constructor = type.GetConstructor(types);

            //we don't need to pass the selector parameter because we already have the IWebElement for this element.
            Element element = (Element)constructor.Invoke(new object[] { "" });

            element.GetByWebElement(webElement);
            row.Add(element.data);
        }
    }

    public override Result VerifyCell(Object data, Object expectedResult, string msg, int columnNumber)
    {
        Type[] types = new Type[1];
        types[0] = typeof(string);
        Type type = columnTypes[columnNumber];

        if (type != null)
        {
            ConstructorInfo constructor = type.GetConstructor(types);
            Element element = (Element)constructor.Invoke(new object[] { "" });
            element.data = data;
            return element.Verify("", expectedResult);
        }
        else
        {
            return new Result (true);
        }
    }

    //verifyCell(page: EnhancedPageObject, data: any, expectedResult: any, message: string, colnumber: number)
    //{
    //    if (this.columnTypes[colnumber] != undefined)
    //    {
    //        var element: element = new this.columnTypes[colnumber]('')
    //        element.data = data
    //        element.verify(page, expectedResult, message)
    //    }
    //    return page
    //}

}