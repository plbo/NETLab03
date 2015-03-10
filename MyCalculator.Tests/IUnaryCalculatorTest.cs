using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MyCalculator.Tests
{
    [TestClass]
    public class IUnaryCalculatorTest: TestBase
    {
        public IUnaryCalculatorTest()
            : base(typeof(IUnaryCalculator))
        {

        }

        [TestMethod]
        public void IUnaryCalculator_IsPublicInterfaceWithOneProperty()
        {
            Assert.IsTrue(_testingType.IsInterface, _testingType.Name + " must be interface");
            Assert.IsTrue(_testingType.IsPublic, _testingType.Name + " must be public");
            Assert.AreEqual(_testingType.GetProperties().Length, 1, _testingType.Name + " contains one property");
        }

        [TestMethod]
        public void IUnaryCalculator_InheritsICalculator()
        {
            var calcInterface = _testingType.GetInterfaces().FirstOrDefault(pi => pi.Equals(CalculatorInterfaceType));

            Assert.IsNotNull(calcInterface, string.Format("IUnaryCalculator inherits {0}", CalculatorInterfaceType.Name));
        }

        [TestMethod]
        public void IUnaryCalculator_HasPublicGetterSetterInnerCalculator()
        {
            TestProperty(InnerCalculatorPropertyName, CalculatorInterfaceType);
        }
    }
}
