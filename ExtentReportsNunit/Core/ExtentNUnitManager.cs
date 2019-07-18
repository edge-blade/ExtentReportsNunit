using ExtentReportsNunit.Attributes;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtentReportsNunit.Core
{
    /// <summary>
    /// All logic related to setting up and evaluating tests.
    /// </summary>
    public static class ExtentNUnitManager
    {
        private static AventStack.ExtentReports.ExtentTest _testSuite;
        private static string _testSuiteName;

        private static Dictionary<string, AventStack.ExtentReports.ExtentTest> _testList = new Dictionary<string, AventStack.ExtentReports.ExtentTest>();

        /* Reporters */
        private static readonly Lazy<AventStack.ExtentReports.ExtentReports> _lazy =
            new Lazy<AventStack.ExtentReports.ExtentReports>(() => new AventStack.ExtentReports.ExtentReports());

        public static AventStack.ExtentReports.ExtentReports Instance { get { return _lazy.Value; } }

        static ExtentNUnitManager() { }

        public static void StartTestSuite(string testSuiteName)
        {
            _testSuiteName = testSuiteName;
            _testSuite = Instance.CreateTest(_testSuiteName, GenerateID());
            _testList.Add(_testSuite.Model.Description, _testSuite);
        }

        public static void StopTestSuite()
        {
            Instance.Flush();
        }

        /// <summary>
        /// Returns a GUID that represents the test
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public static string StartTest(ITest test)
        {
            var testId = GenerateID();            
            var childTest = _testSuite.CreateNode(test.FullName, testId);
            _testList.Add(testId, childTest);
            return testId;
        }

        /// <summary>
        /// Allows users to close out the test on their own via attributes
        /// </summary>
        /// <param name="testId"></param>
        /// <param name="context"></param>
        /// <param name="nunitTest"></param>
        /// <param name="includeScreenShotsOnFailure"></param>
        public static void StopTest(string testId, TestContext context, ITest nunitTest, bool includeScreenShotsOnFailure)
        {
            var test = _testList[testId];
            var attributes = nunitTest.Method.GetCustomAttributes<NUnitAttribute>(true).ToList();

            attributes.AddRange(GetTestFixture(nunitTest).GetCustomAttributes<NUnitAttribute>(true).ToList());
            ProcessAttributes(test, attributes);

            EvaluateTestResults(test, context, includeScreenShotsOnFailure);
        }

        private static void EvaluateTestResults(AventStack.ExtentReports.ExtentTest test, TestContext context, bool includeScreenShotsOnFailure)
        {
            var result = context.Result;
            switch(result.Outcome.Status)
            {
                case TestStatus.Passed:
                    test.Pass("Pass");
                    break;
                case TestStatus.Skipped:
                    test.Skip("Skipped");
                    break;
                case TestStatus.Inconclusive:
                    test.Info("Inconclusive");
                    break;
                case TestStatus.Warning:
                    test.Warning("Warning: " + result.StackTrace);
                    break;
                case TestStatus.Failed:
                default:
                    test.Fail(result.StackTrace);
                    if (includeScreenShotsOnFailure)
                    {
                        DirectoryInfo taskDirectory = new DirectoryInfo(context.WorkDirectory);
                        FileInfo[] files = taskDirectory.GetFiles($"{test.Model.Name}*.png");
                        // if screenshot exists, add it
                        if (files.Count() > 0)
                        {
                            FileInfo file = files.Last();
                            // Add the screenshot
                            test.AddScreenCaptureFromPath(file.FullName);
                        }

                    }
                    break;
            }
        }

        private static void ProcessAttributes(AventStack.ExtentReports.ExtentTest test, List<NUnitAttribute> attributes)
        {
            foreach(var attribute in attributes)
            {
                switch(attribute)
                {
                    case ExtentNUnitCategoryAttribute categoryAttribute:
                        test.AssignCategory(categoryAttribute.ExtentCategory);
                        break;
                    case ExtentNUnitAuthorAttribute authorAttribute:
                        test.AssignAuthor(authorAttribute.ExtentAuthor);
                        break;
                    case ExtentNUnitDeviceAttribute deviceAttribute:
                        test.AssignAuthor(deviceAttribute.ExtentDevice);
                        break;
                    case ExtentNUnitDescriptionAttribute descriptionAttribute:
                        test.Model.Description = $"{descriptionAttribute.Description} - {test.Model.Description}";
                        break;
                    default:
                        break;
                }
            }
        }

        private static string GenerateID()
        {
            return Guid.NewGuid().ToString();
        }
        
        private static TestFixture GetTestFixture(ITest test)
        {
            var currentTest = test;
            var isTestSuite = currentTest.IsSuite;
            while (isTestSuite != true)
            {
                currentTest = currentTest.Parent;
                if (currentTest is ParameterizedMethodSuite) currentTest = currentTest.Parent;
                isTestSuite = currentTest.IsSuite;
            }

            return (TestFixture)currentTest;
        }

        /// <summary>
        /// Returns the given Extent test given the testId 
        /// </summary>
        /// <param name="testId"></param>
        /// <returns></returns>
        public static AventStack.ExtentReports.ExtentTest GetTest(string testId)
        {
            return _testList[testId];
        }
    }
}
