using System;

namespace ExtentReportsNunit.Reporters.TestReporters
{
    public class KlovTestReporter : ITestReporter
    {
        public ITestReporter AttachTestReporter(AventStack.ExtentReports.ExtentReports reporter, string location)
        {
            throw new NotImplementedException();
        }

        public ITestReporter AttachTestReporter(AventStack.ExtentReports.ExtentReports reporter, string projectName, string buildName, string host, int port, string address)
        {
            var klov = new AventStack.ExtentReports.Reporter.ExtentKlovReporter(projectName, buildName);
            klov.InitMongoDbConnection(host, port);
            klov.InitKlovServerConnection(address);
            reporter.AttachReporter(klov);

            return this;
        }
    }
}
