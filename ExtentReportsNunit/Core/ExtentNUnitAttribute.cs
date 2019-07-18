using ExtentReportsNunit.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace ExtentReportsNunit
{
    /// <summary>
    /// Creates a tests suite, recommended to add this property to a base test that all other test will inherit from as it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExtentNUnitAttribute : PropertyAttribute, ITestAction
    {
        private string _testSuiteName;

        public ActionTargets Targets => ActionTargets.Suite;
        
        public ExtentNUnitAttribute(string testSuiteName = "AllTests")
        {
            _testSuiteName = testSuiteName;
        }

        // OneTimeSetUp
        public void BeforeTest(ITest test)
        {
            // Init TestManager and start base test
            ExtentNUnitManager.StartTestSuite(_testSuiteName);

        }

        // OneTimeTearDown
        public void AfterTest(ITest test)
        {
            ExtentNUnitManager.StopTestSuite();
        }
    }
}
