using NUnit.Framework;
using System;

namespace ExtentReportsNunit.Attributes
{
    /// <summary>
    /// Adds Author property to Extent Reports
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class ExtentNUnitAuthorAttribute : NUnitAttribute
    {
        internal string ExtentAuthor { get; }
        public ExtentNUnitAuthorAttribute(string extentAuthor)
        {
            ExtentAuthor = extentAuthor;
        }
    }
}
