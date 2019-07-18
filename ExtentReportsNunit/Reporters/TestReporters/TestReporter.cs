using System;
using System.Collections.Generic;

namespace ExtentReportsNunit.Reporters.TestReporters
{
    public class TestReporter
    {
        private readonly Dictionary<TestReporterActions, TestReporterFactory> _factories;

        public TestReporter()
        {
            _factories = new Dictionary<TestReporterActions, TestReporterFactory>();

            foreach (TestReporterActions action in Enum.GetValues(typeof(TestReporterActions)))
            {
                var factory = (TestReporterFactory)Activator.CreateInstance(Type.GetType("ExtentReportsNunit.Reporters.TestReporterFactories." + Enum.GetName(typeof(TestReporterActions), action) + "Factory"));
                _factories.Add(action, factory);
            }
        }

        public ITestReporter ExecuteCreation(TestReporterActions action, AventStack.ExtentReports.ExtentReports reporter, TestReporterParams reporterParams) => _factories[action].Create(reporter, reporterParams);

    }
}
