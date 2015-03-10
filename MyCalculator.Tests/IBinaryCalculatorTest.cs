using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MyCalculator.Tests
{
    [TestClass]
    public class IBinaryCalculatorTest: TestBase
    {
        public IBinaryCalculatorTest()
            : base(typeof(IBinaryCalculator))
        {

        }

        [TestMethod]
        public void IBinaryCalculator_IsPublicInterfaceWithTwoProperties()
        {
            Assert.IsTrue(_testingType.IsInterface, _testingType.Name + " must be interface");
            Assert.IsTrue(_testingType.IsPublic, _testingType.Name + " must be public");
            Assert.AreEqual(_testingType.GetProperties().Length, 2, _testingType.Name + " contains two properties");
        }

        [TestMethod]
        public void IBinaryCalculator_InheritsICalculator()
        {
            var calcInterface = _testingType.GetInterfaces().FirstOrDefault(pi => pi.Equals(CalculatorInterfaceType));

            Assert.IsNotNull(calcInterface, string.Format("IBinaryCalculator inherits {0}", CalculatorInterfaceType.Name));
        }

        [TestMethod]
        public void IBinaryCalculator_HasPublicGetterSetterLeft()
        {
            TestProperty(LeftPropertyName, CalculatorInterfaceType);
        }

        [TestMethod]
        public void IBinaryCalculator_HasPublicGetterSetterRight()
        {
            TestProperty(RightPropertyName, CalculatorInterfaceType);
        }
    }
}
