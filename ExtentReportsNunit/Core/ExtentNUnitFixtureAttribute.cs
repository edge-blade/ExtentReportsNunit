using ExtentReportsNunit.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;

namespace ExtentReportsNunit
{

    /// <summary>
    /// Setups up a fixture that adds every test to the Extent collection and evaluates all tests.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExtentNUnitFixtureAttribute : PropertyAttribute, ITestAction
    {
        public ActionTargets Targets => ActionTargets.Test;
        public string TestId;
        public bool AttachScreenShot = false;

        /// <summary>
        /// attachScreenShotOnFailure - This looks for a png in the results directory that begins with the fullName property of ITest from NUnit.
        /// </summary>
        /// <param name="attachScreenShotOnFailure"></param>
        public ExtentNUnitFixtureAttribute(bool attachScreenShotOnFailure)
        {
            AttachScreenShot = attachScreenShotOnFailure;
        }

        // Before Each Test
        public void BeforeTest(ITest test)
        {
            TestId = ExtentNUnitManager.StartTest(test);
        }

        // After Each Test
        public void AfterTest(ITest test)
        {
            ExtentNUnitManager.StopTest(TestId, TestContext.CurrentContext, test, AttachScreenShot);
        }

    }
}
