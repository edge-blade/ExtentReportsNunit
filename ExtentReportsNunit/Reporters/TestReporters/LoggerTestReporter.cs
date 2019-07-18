using System;

namespace ExtentReportsNunit.Reporters.TestReporters
{
    public class LoggerTestReporter : ITestReporter
    {
        public ITestReporter AttachTestReporter(AventStack.ExtentReports.ExtentReports reporter, string location)
        {
            var logger = new AventStack.ExtentReports.Reporter.ExtentLoggerReporter(location);
            reporter.AttachReporter(logger);

            return this;
        }

        public ITestReporter AttachTestReporter(AventStack.ExtentReports.ExtentReports reporter, string projectName, string buildName, string host, int port, string address)
        {
            throw new NotImplementedException();
        }
    }
}
