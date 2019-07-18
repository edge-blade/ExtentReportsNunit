namespace ExtentReportsNunit.Reporters
{
    public abstract class TestReporterFactory
    {
        public abstract ITestReporter Create(AventStack.ExtentReports.ExtentReports reports, TestReporterParams reporterParams);
    }

    public enum TestReporterActions
    {
        Html,
        Klov,
        Logger
    }
}
