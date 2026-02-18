using NUnit.Framework;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest

{
    [TestFixture]

    class CashRebalanceTest : BaseTest
    {
         [TestCase(1677138, "8186")]
        public void TestCase8186(int testCaseId, string clientId)
        {
            new CashRebalanceWorkflow(clientId).Execute();
        }

        [TestCase(1677139, "8187")]
        public void TestCase8187(int testCaseId, string clientId)
        {
            new CashRebalanceWorkflow(clientId).Execute();
        }

        [TestCase(1677140, "8195")]
        public void TestCase8195(int testCaseId, string clientId)
        {
            new CashRebalanceWorkflow(clientId).Execute();
        }

        [TestCase(1677141, "8213")] //Client already in balance for cash
        public void TestCase8213(int testCaseId, string clientId)
        {
            new CashRebalanceWorkflow(clientId).Execute();
        }

        [TestCase(139834, "8191")] //Rebalance with Cash goal min, mid, max
        public void TestCase8191(int testCaseId, string clientId)
        {
            new CashRebalanceWorkflow(clientId).Execute();
        }
    }
}