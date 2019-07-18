using ExtentReportsNunit.Reporters.TestReporters;

namespace ExtentReportsNunit.Reporters.TestReporterFactories
{
    public class HtmlFactory : TestReporterFactory
    {
        public override ITestReporter Create(AventStack.ExtentReports.ExtentReports reports, TestReporterParams reporterParams)
        {
            return new HtmlTestReporter().AttachTestReporter(reports, reporterParams.testResultsPath);
        }
    }
}
