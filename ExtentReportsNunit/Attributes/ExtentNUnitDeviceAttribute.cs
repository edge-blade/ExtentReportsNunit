using NUnit.Framework;
using System;

namespace ExtentReportsNunit.Attributes
{
    /// <summary>
    /// Adds a device designation to the reports
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class ExtentNUnitDeviceAttribute : NUnitAttribute
    {
        internal string ExtentDevice { get; }
        public ExtentNUnitDeviceAttribute(string extentDevice)
        {
            ExtentDevice = extentDevice;
        }
    }
}
