using System;
using TrxUITest.src.pages;
using TrxUITest.src.tests.utils;
using TrxUITest.src.utils;

namespace TrxUITest
{
    public static class FlyerTestBase
    {
        private static IntegrationProviderSettings integrationProviderSettings = new IntegrationProviderSettings("Fix Flyer", "api@morningstar", "test");

        private static bool IsWindows()
        {
            var windowsHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (windowsHome.Length == 0) return false;
            else return true;
        }

        private static bool IsLocalEnvironment()
        {
            return (Test.webURL.Contains("localhost"));
        }

        public static void SetUpFlyerData()
        {
            Database.RunQuery(Test.dbServer, "update CRDivisions set ClientName='" + Test.trxUserName + "'");
            Database.RunQuery(Test.dbServer, "update CRTRExGlobal set BypassFixFlyer='0'"); //default is 1
            Database.RunQuery(Test.dbServer, "update CRAccountMaster set Custodian='SCHWAB', AccountType='IRA' where AccountNumber IN ('9999-0085', '9999-0086', '9999-0087', '9999-0130')");

            //Set up Flyer integration
            IntegrationProviderSettingsPage.GoTo();
            IntegrationProviderSettingsPage.WaitForPageToLoad();
            IntegrationProviderSettingsPage.Update(integrationProviderSettings);

            //Create flyer groupset
            Database.RunQuery(Test.dbServer, "insert into CRGroupSet (groupset, Description, Division) values('flyer', 'flyer test', 1)");

            //Add selected clients to "flyer" rebalance set
            Database.RunQuery(Test.dbServer, "update CRHousehold set GroupSetID=33 where HouseHold in ('8223', '8195', '8191', '8190', '8192', '8207', '8216', '8202', '8214', '8201', '8226', '8198')");
        }

        public static void TestCase()
        {
            if (!IsWindows())
            {
                Console.WriteLine("This test case cannot be run in Docker, due to inability to access fileshare or local file system of Trx Web server.");
                return;
            }

            //const analysisPage = browser.page.analysisPage() as AnalysisPage
            //const rebalanceButton = analysisPage.elements["rebalanceButton"].selector
            //const marPage = browser.page.multiAnalysisRebalancePage() as MultiAnalysisRebalancePage

            //Rebalance the flyer rebalance set using proposal edits to invoke the code that handles rounding and truncation of fractional shares.

            ProposalEditsClass edits0086 = new ProposalEditsClass();
            edits0086.clientId = "8207";
            edits0086.edits = new EditClass[] { new EditPositionByAmount(new Position("9999-0086", "SRE"), "-5000") };

            ProposalEditsClass edits0087 = new ProposalEditsClass();
            edits0087.clientId = "8207";
            edits0087.edits = new EditClass[] { new EditPosition(new Position("9999-0087", "SRE"), EditAction.sellAll) };

            ProposalEditsClass edits0131 = new ProposalEditsClass();
            edits0131.clientId = "8223";
            edits0131.edits = new EditClass[] { new EditPosition(new Position("9999-0131", "SRE"), EditAction.sellAll) };

            //Sell all MF with fractional shares
            ProposalEditsClass edits0055 = new ProposalEditsClass();
            edits0055.clientId = "8192";
            edits0055.edits = new EditClass[] { new EditPosition(new Position("9999-0055", "DFEOX"), EditAction.sellAll) };

            AnalysisPageFilter[] filters = { new AnalysisPageFilter(MultiAnalysisRebalancePage.Selectors.rebalanceSetFilter, "flyer") };
            ProposalEditsClass[] edits = new ProposalEditsClass[] { edits0086, edits0087, edits0131, edits0055 };

            new MultiFlyerRebalanceWorkflow().Rebalance(AnalysisPage.Selectors.rebalanceButton, new MultiAnalysisRebalancePage(), filters, edits);
        }
    }
}