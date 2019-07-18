using ExtentReportsNunit.Reporters.TestReporters;

namespace ExtentReportsNunit.Reporters.TestReporterFactories
{
    public class KlovFactory : TestReporterFactory
    {
        public override ITestReporter Create(AventStack.ExtentReports.ExtentReports reports, TestReporterParams reporterParams)
        {
            return new KlovTestReporter().AttachTestReporter(
                reports,
                reporterParams.projectName, 
                reporterParams.buildName, 
                reporterParams.host, 
                reporterParams.port, 
                reporterParams.address);
        }
    }
}
