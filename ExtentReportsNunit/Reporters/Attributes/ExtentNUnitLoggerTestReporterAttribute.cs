using ExtentReportsNunit.Core;
using ExtentReportsNunit.Reporters.TestReporters;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace ExtentReportsNunit.Reporters.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExtentNUnitLoggerTestReporterAttribute : PropertyAttribute, ITestAction
    {
        public ActionTargets Targets => ActionTargets.Suite;
        private TestReporterParams _params;

        public ExtentNUnitLoggerTestReporterAttribute()
        {
            _params = new TestReporterParams()
            {
                testResultsPath = TestContext.CurrentContext.WorkDirectory
            };
            new TestReporter().ExecuteCreation(TestReporterActions.Html, ExtentNUnitManager.Instance, _params);
        }

        public void AfterTest(ITest test)
        {
        }

        public void BeforeTest(ITest test)
        {
        }
    }
}
