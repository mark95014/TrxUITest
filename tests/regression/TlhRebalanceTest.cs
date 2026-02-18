using NUnit.Framework;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest

{
    [TestFixture]

    public class TlhRebalanceTest : BaseTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TradeProposalsPage.GoTo();
            TradeProposalsPage.CancelProposals();
        }

        [TestCase(1677142, "8188")]
        public void TestCase8188(int testCaseId, string clientId)
        {
            new TlhRebalanceWorkflow(clientId).Execute();
        }

        [TestCase(1677143, "8195")]
        public void TestCase8195(int testCaseId, string clientId)
        {
            new TlhRebalanceWorkflow(clientId).Execute();
        }

        [TestCase(1677144, "8208")]
        public void TestCase8208(int testCaseId, string clientId)
        {
            new TlhRebalanceWorkflow(clientId).Execute();
        }

        [TestCase(1677145, "8213")] //Client with no TLH opportunities
        public void TestCase8213(int testCaseId, string clientId)
        {
            new TlhRebalanceWorkflow(clientId).Execute();
        }
    }
}