### Extent Reports - NUnit

Extent NUnit was written using the .NET CORE Fork of Extent Reports and provides attribute wrappers to easily build test reports from the Community Edition.

### Installation 

-- TODO

### Available Attributes

* **Core (Required)**
  * ExtentNUnit
  * ExtentNUnitFixture
* **Descriptors**
  * ExtentNUnitCategory
  * ExtentNUnitDescription
  * ExtentNUnitAuthor
  * ExtentNUnitDevice
* **Reporters**
  * ExtentNUnitHtmlTestReporter
  * ExtentNUnitKlovTestReporter
  * ExtentNUnitLoggerTestReporter

### Additional Context
A static class shared among all tests `ExtentNUnitManager` builds the test results and provides some access into the Extent framework.

### Usage

The `ExtentNUnit` attribute and `ExtentNUnitFixture` are required to be on all classes that have tests you want reported. It's recommended that you create a BaseTest class that has those attributes, and then inherit all tests from that Base Test. Then you can use `ExtentNUnitCategory` to tag tests and group them on the Tags screen in ExtentReports.

```cs

[TestFixture]
[ExtentNUnit("Suite Tests")]
[ExtentNUnitFixture(false)]
[ExtentNUnitCategory("Smoke Tests")]
[ExtentNUnitDescription("Smoke Test Component")]
[ExtentNUnitHtmlTestReporter]
public class Tests
{

    [Test]
    [ExtentNUnitCategory("Math Tests")]
    [ExtentNUnitDescription("Does simple arithmetic.")]
    public void MathTest()
    {
            // perform math
            var a = 15;
            var b = 26;
            var c = 5;
            var result = (a * b) / c;
            Assert.AreEqual(78, result);
    }
}
```  
