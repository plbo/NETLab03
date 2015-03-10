using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyCalculator.Tests
{
    public abstract class BinaryCalculatorTestBase: CalcTestBase
    {
        public BinaryCalculatorTestBase(Type typeToTest)
            : base(typeToTest)
        {

        }

        [TestMethod]
        public void IsPublicNonAbstractClassAndInheritsBinaryCalculator()
        {
            Assert.IsTrue(_testingType.IsClass, string.Format("{0} is class", _testingType.Name));
            Assert.IsTrue(_testingType.IsPublic, string.Format("{0} is public", _testingType.Name));
            Assert.IsFalse(_testingType.IsAbstract, string.Format("{0} is abstract class", _testingType.Name));
            Assert.IsTrue(typeof(BinaryCalculator).Equals(_testingType.BaseType),
                string.Format("{0} inherits BinaryCalculator", _testingType.Name));
        }
    }
}
