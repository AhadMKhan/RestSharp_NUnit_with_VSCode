using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace RestSharpDemo.Util
{
    public class Assertions
    {
        public static void ResponseCodeAssert(int ExpectedResponseCode, int actualResponseCode)
        {
            Assert.That(actualResponseCode, Is.EqualTo(ExpectedResponseCode));
        }

        public static void AssertNotNull(string ExpectedResult)
        {
            Assert.That(ExpectedResult, Is.Not.Null.Or.Empty, "Failed to get "+ExpectedResult+".");
        }

        public static void ResponseBodyAssert(string ExpectedResponse, string ActualResponse)
        {
            Assert.That(ExpectedResponse, Is.EqualTo(ActualResponse));
        }
    }
}
