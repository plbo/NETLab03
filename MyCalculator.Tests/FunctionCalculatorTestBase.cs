using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyCalculator.Tests
{
    public abstract class FunctionCalculatorTestBase: CalcTestBase
    {
        public FunctionCalculatorTestBase(Type typeToTest)
            : base(typeToTest)
        {

        }

        [TestMethod]
        public void IsPublicNonAbstractClassAndInheritsFunctionCalculator()
        {
            Assert.IsTrue(_testingType.IsClass, string.Format("{0} is class", _testingType.Name));
            Assert.IsTrue(_testingType.IsPublic, string.Format("{0} is public", _testingType.Name));
            Assert.IsFalse(_testingType.IsAbstract, string.Format("{0} is abstract class", _testingType.Name));        
            Assert.IsTrue(typeof(FunctionCalculator).Equals(_testingType.BaseType),
                string.Format("{0} inherits FunctionCalculator", _testingType.Name));
        }

        [TestMethod]
        public void HasConstructorThatTakesAnotherCalculator()
        {
            GetConstructor(_testingType, CalculatorInterfaceType);
        }
    }
}
