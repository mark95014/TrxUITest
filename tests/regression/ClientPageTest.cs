using NUnit.Framework;
using System.Threading;
using TrxUITest.src.pages;
using TrxUITest.src.utils;

namespace TrxUITest

{
    [TestFixture]

    class ClientPageTest : BaseTest
    {
        [TestCase(1677146, "8186")]
        public void TestCase8186(int testCaseId, string clientId)
        {
            ClientPage.GoTo(clientId);
            ClientPage.VerifyPage();
        }

        [TestCase(1677147, "8187")]
        public void TestCase8187(int testCaseId, string clientId)
        {
            ClientPage.GoTo(clientId);
            ClientPage.VerifyPage();
        }

        [TestCase(1677148, "8188")]
        public void TestCase8188(int testCaseId, string clientId)
        {
            ClientPage.GoTo(clientId);
            ClientPage.VerifyPage();
        }

        [TestCase(1677149, "8189")]
        public void TestCase8189(int testCaseId, string clientId)
        {
            ClientPage.GoTo(clientId);
            ClientPage.VerifyPage();
        }

        [TestCase(3377934, "8198")]
        public void TestCase8198(int testCaseId, string clientId)
        {
            ClientPage.GoTo(clientId);
            ClientPage.VerifyPage();
        }
    }
}
