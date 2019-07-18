
using ExtentReportsNunit.Attributes;
using ExtentReportsNunit.Reporters.Attributes;
using NUnit.Framework;

namespace ExtentReportsNunit.TestSamples
{
    [TestFixture]
    [ExtentNUnit("Suite Tests")]
    [ExtentNUnitFixture(false)]
    [ExtentNUnitCategory("Smoke Tests")]
    [ExtentNUnitDescription("Smoke Test Component")]
    [ExtentNUnitHtmlTestReporter]
    public class SuiteTests
    {
        [Test]
        [ExtentNUnitCategory("Math Tests")]
        [ExtentNUnitDescription("Does simple arithmetic.")]
        public void SampleTest1()
        {
            // perform math
            var a = 15;
            var b = 26;
            var c = 5;

            var result = (a * b) / c;

            Assert.AreEqual(78, result);
        }
        
        [Test]
        [ExtentNUnitCategory("String Tests")]
        public void SampleTest2()
        {
            // perform math
            var a = "catapult";
            var b = "math";

            var result = a + b;

            Assert.AreEqual("catapultmath", result);
        }
    }
}
