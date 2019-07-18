using ExtentReportsNunit.Reporters;
using ExtentReportsNunit.Reporters.TestReporters;
using NUnit.Framework;

namespace ExtentReportsNunit.TestSamples
{
    [TestFixture]
    public class FactoryTests
    {

        [Test]
        public void FactoryTests_Apply_Multiple_Factories()
        {
            var extent = new AventStack.ExtentReports.ExtentReports();

            var param = new TestReporterParams()
            {
                testResultsPath = "tmpResPath",
                address = "http://tmp",
                buildName = "tmpBuild",
                host = "tmpHost",
                port = 12345,
                projectName = "tmpProject"
            };

            new TestReporter().ExecuteCreation(TestReporterActions.Html, extent, param);
            new TestReporter().ExecuteCreation(TestReporterActions.Logger, extent, param);

            Assert.AreEqual(2, extent.StartedReporterList.Count);
        }
    }
}
