using ExtentReportsNunit.Reporters.TestReporters;

namespace ExtentReportsNunit.Reporters.TestReporterFactories
{
    public class LoggerFactory : TestReporterFactory
    {
        public override ITestReporter Create(AventStack.ExtentReports.ExtentReports reports, TestReporterParams reporterParams)
        {
            return new LoggerTestReporter().AttachTestReporter(reports, reporterParams.testResultsPath);
        }
    }
}
