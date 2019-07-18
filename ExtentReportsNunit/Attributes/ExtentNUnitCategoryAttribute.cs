using NUnit.Framework;
using System;

namespace ExtentReportsNunit.Attributes
{
    /// <summary>
    /// Adds category/tag property to Extent Reports
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class ExtentNUnitCategoryAttribute : NUnitAttribute
    {
        internal string ExtentCategory { get; }
        public ExtentNUnitCategoryAttribute(string extentCategory)
        {
            ExtentCategory = extentCategory;
        }
    }
}
