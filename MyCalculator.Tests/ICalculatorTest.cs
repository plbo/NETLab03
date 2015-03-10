using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.Tests
{
    [TestClass]
    public class ICalculatorTest : CalcTestBase
    {
        public ICalculatorTest()
            : base(typeof(ICalculator))
        {

        }

        [TestMethod]
        public void ICalculator_IsPublicInterfaceWithOneMethod()
        {
            Assert.IsTrue(_testingType.IsInterface, _testingType.Name + " must be interface");
            Assert.IsTrue(_testingType.IsPublic, _testingType.Name + " must be public");
            Assert.AreEqual(_testingType.GetMethods().Length, 1, _testingType.Name + " contains one operation");
        }
    }
}
