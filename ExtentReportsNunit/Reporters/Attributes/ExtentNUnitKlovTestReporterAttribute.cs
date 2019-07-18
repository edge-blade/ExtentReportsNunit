using ExtentReportsNunit.Core;
using ExtentReportsNunit.Reporters.TestReporters;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace ExtentReportsNunit.Reporters.Attributes
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExtentNUnitKlovTestReporterAttribute : PropertyAttribute, ITestAction
    {
        public ActionTargets Targets => ActionTargets.Suite;
        private TestReporterParams _params;
        
        public ExtentNUnitKlovTestReporterAttribute(string projectName, string buildName, string host, int port, string address)
        {
            _params = new TestReporterParams()
            {
                projectName = projectName,
                buildName = buildName,
                address = address,
                port = port,
                host = host
            };
            new TestReporter().ExecuteCreation(TestReporterActions.Klov, ExtentNUnitManager.Instance, _params);
        }

        public void AfterTest(ITest test)
        {
        }

        public void BeforeTest(ITest test)
        {
        }
    }
}
