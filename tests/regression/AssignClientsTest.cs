using NUnit.Framework;
using TrxUITest.src.utils;
using TrxUITest.src.pages;

namespace TrxUITest
{
    [TestFixture]

    class AssignClientsTest : BaseTest
    {

        //    "Assign Clients: Change Client": (browser: Trx) => {changeClientTestCase(browser, '3228745', '8187', '8186', [])},
        [TestCase(3228745)]
        public void NewClient(int testCaseId)
        {
            //newClientTestCase(browser: Trx, testCaseId: string, sourceClientId: string, newClientName: string, model: string, groups: string[])

        }
        //"Assign Clients: New Client": (browser: Trx) => {newClientTestCase(browser, '3228744', '8187', 'Newman, Franz', '2014 - 50/50', [])}
    }
}

/*import { Trx, ClientsPage, AssignClientsPage, ClientPage} from '../../types/NightwatchBrowser'
import { testControl } from '../../utils/testControl'
import { Database } from '../../utils/Database'
import { login } from '../../utils/login'
import { expectedResultsFile } from '../../utils/expectedResultsFile'
import { TestRail } from '../../utils/TestRail'
const path = require("path")

function changeClientTestCase(browser: Trx, testCaseId: string, sourceClientId: string, targetClientId: string, groups: string[]) {
    if (!testControl.inAllowedGroups(groups)) {return}
    browser.globals.testCaseId = testCaseId

    const assignClientsPage: AssignClientsPage = beginAssignClients(browser, testCaseId)

    browser.pause(2000)

    assignClientsPage.waitForElementPresent(assignClientsPage.elements['assignTypePulldown'].selector)
    browser.setValue(assignClientsPage.elements['assignTypePulldown'].selector, 'Change Client')
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['selectClientPulldown'].selector)
    browser.setValue(assignClientsPage.elements['selectClientPulldown'].selector, targetClientId)

    updateClients(browser, assignClientsPage, sourceClientId)
    VerifyClients(browser, targetClientId, sourceClientId)
}

function newClientTestCase(browser: Trx, testCaseId: string, sourceClientId: string, newClientName: string, model: string, groups: string[]) {
    if (!testControl.inAllowedGroups(groups)) {return}
    browser.globals.testCaseId = testCaseId

    const assignClientsPage: AssignClientsPage = beginAssignClients(browser, testCaseId)
    
    browser.pause(2000)
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['assignTypePulldown'].selector)
    browser.setValue(assignClientsPage.elements['assignTypePulldown'].selector, 'New Client')
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['newClientName'].selector)
    browser.setValue(assignClientsPage.elements['newClientName'].selector, newClientName)
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['model'].selector)
    browser.setValue(assignClientsPage.elements['model'].selector, model)

    const targetClientId = '' //retrieve from screen

    updateClients(browser, assignClientsPage, sourceClientId)
    VerifyClients(browser, newClientName, sourceClientId)
}

function beginAssignClients(browser: Trx, testCaseId: string): AssignClientsPage {
    const clientsPage = browser.page.clientsPage() as ClientsPage
    clientsPage.navigate().waitForPageToLoad()

    //click assign client
    browser.pause(2000)
    clientsPage.waitForElementPresent('@assignClientsButton')
    clientsPage.click('@assignClientsButton')
    var assignClientsPage = browser.page.assignClientsPage() as AssignClientsPage
    //browser.globals.pageInstance = '1' 
    assignClientsPage.waitForPageToLoad().verifyPage(browser)
    return assignClientsPage
}

function updateClients(browser: Trx, assignClientsPage: AssignClientsPage, sourceClientId: string) {
  
    browser.pause(2000)
    assignClientsPage.filterById(sourceClientId)

    //select 1st 2 accounts of target client
    browser.pause(2000)
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['firstCheckbox'].selector)
    assignClientsPage.click(assignClientsPage.elements['firstCheckbox'].selector)
    assignClientsPage.click(assignClientsPage.elements['secondCheckbox'].selector)

    //click update, verify grid
    browser.pause(2000)
    console.log('clicking update')
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['updateButton'].selector)
    assignClientsPage.click(assignClientsPage.elements['updateButton'].selector)
    //browser.globals.pageInstance = '2'
    assignClientsPage.verifyPage(browser)

    //save, confirm, wait for recalc
    browser.pause(2000)
    console.log('clicking save')
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['saveButton'].selector)
    assignClientsPage.click(assignClientsPage.elements['saveButton'].selector)
    browser.pause(2000)
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['confirmButton'].selector)
    assignClientsPage.click(assignClientsPage.elements['confirmButton'].selector)
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['recalculating'].selector)
    assignClientsPage.waitForElementNotPresent(assignClientsPage.elements['recalculating'].selector)

    //erase current client filter, verify grid
    browser.pause(2000)
    assignClientsPage.filterById('')
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['refreshButton'].selector)
    assignClientsPage.click(assignClientsPage.elements['refreshButton'].selector)
    assignClientsPage = browser.page.assignClientsPage() as AssignClientsPage
    browser.pause(2000)
    //browser.globals.pageInstance = '3'
    assignClientsPage.verifyPage(browser)
    assignClientsPage.waitForElementPresent(assignClientsPage.elements['exitButton'].selector)
    assignClientsPage.click(assignClientsPage.elements['exitButton'].selector)
}

function VerifyClients(browser: Trx, targetClient: string, sourceClientId: string) {
    //go to client page for the target client, verify client page, which also verifies accounts, positions, etc.
    browser.pause(2000)
    const clientPage1 = browser.page.clientPage() as ClientPage
    clientPage1.api.perform(() => { //without perform, the expected results used the last key (all '2')
        clientPage1.goto(browser, targetClient).waitForPageToLoad()
        //browser.globals.pageInstance = '1'
        clientPage1.verifyPage(browser)
    })

    //go to client from which accounts were taken, verify client page
    browser.pause(2000)
    const clientPage2 = browser.page.clientPage() as ClientPage
    clientPage2.api.perform(() => {
        clientPage2.goto(browser, sourceClientId).waitForPageToLoad()
        //browser.globals.pageInstance = '2'
        clientPage2.verifyPage(browser)
    })
}

export = {

    before: function (browser: Trx, done: () => void) {
        expectedResultsFile.init(browser, path.basename(__dirname))
        browser.perform(async () => {
            await Database.restore(browser)
            done()
        })
    },

    after: function (browser: Trx, done: () => void) {
        expectedResultsFile.close(browser)
        browser.signOut().end()
        browser.perform(async () => {
            await Database.cleanup(browser)
            done()
        })
    },
    
    afterEach: function(browser: Trx) {
        TestRail.updateTestRun(browser)
    },

    disabled: false,

    "login": (browser: Trx) => {login.execute(browser)},
    "Assign Clients: Change Client": (browser: Trx) => {changeClientTestCase(browser, '3228745', '8187', '8186', [])},
    "Assign Clients: New Client": (browser: Trx) => {newClientTestCase(browser, '3228744', '8187', 'Newman, Franz', '2014 - 50/50', [])}
}
*/