using NUnit.Framework;
using System;

namespace ExtentReportsNunit.Attributes
{
    /// <summary>
    /// Adds additional descriptions to the Extent reports
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class ExtentNUnitDescriptionAttribute : NUnitAttribute
    {
        internal string Description { get; }
        public ExtentNUnitDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
