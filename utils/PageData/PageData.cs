using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using TrxUITest.src.utils;

public class PageData
{
    public void Get()
    {
        foreach (FieldInfo field in GetType().GetFields())
        {
            //if (field != null && field.FieldType == typeof(Element))
            if (field != null)
                {
                MethodInfo method = field.FieldType.GetMethod("Get");
                method.Invoke(field.GetValue(this), new object[] { });
            }
        }
    }

    public void Verify(JObject expectedResult, string dataLabel)
    {
        foreach (FieldInfo field in GetType().GetFields())
        {
            if (field != null)
            {
                JObject expectedObject = (JObject)expectedResult[field.Name];
                Object expected = expectedObject["data"];
                MethodInfo VerifyMethod = field.FieldType.GetMethod("Verify");
                string dataName = dataLabel + "." + field.Name;
                Result result = (Result)VerifyMethod.Invoke(field.GetValue(this), new object[] { dataName, expected });
                Test.results.Add(result);
            }
        }
    }
}