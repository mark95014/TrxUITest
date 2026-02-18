This is an automated test of the Trx web application.

### How to run the tests
* **Docker method**
  * Copy ../TestRail into the TrxUITest directory *
  * cd to the TrxUITest directory
  * docker-compose up
* **Visual Studio method**
  * Open Test->Test Explorer and run test or test case by right-clicking and choosing Run or Debug.
* **Command line method**
  * Open a Bash shell
  * cd to the top level directory of this project
  * testfqdn=TrxUITest.RebalanceSingleTest5
  * alias trxuitest='dotnet vstest --TestCaseFilter:"FullyQualifiedName=$testfqdn" --settings:.runsettings bin/Debug/netcoreapp3.1/TrxUITest.dll'

MSDOMAIN1+mnorman@US-HJMFSQ3 MINGW32 ~/source/repos/TrxUITest (master)
$ testfqdn=TrxUITest.RebalanceSingleTest5

### Environment
* Set the environment (qa, uat, stg) in .runsettings
*    TEST 3
