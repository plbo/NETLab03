using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MyCalculator.Tests
{
    [TestClass]
    public class FunctionCalculatorTest : CalcTestBase
    {
        public FunctionCalculatorTest()
              : base(typeof(FunctionCalculator))
        {

        }

        [TestMethod]
        public void FunctionCalculator_IsPublicAbstractClass()
        {
            Assert.IsTrue(_testingType.IsClass, string.Format("{0} is class", _testingType.Name));
            Assert.IsTrue(_testingType.IsPublic, string.Format("{0} is public", _testingType.Name));
            Assert.IsTrue(_testingType.IsAbstract, string.Format("{0} is abstract class", _testingType.Name));
        }

        [TestMethod]
        public void FunctionCalculator_ImplementsIUnaryCalculator()
        {
            var unaryCalcInterface = _testingType.GetInterfaces().FirstOrDefault(pi => pi.Equals(typeof(IUnaryCalculator)));

            Assert.IsNotNull(unaryCalcInterface, string.Format("{0} implements IUnaryCalculator", _testingType.Name));
        }

        [TestMethod]
        public void FunctionCalculator_HasProtectedAbstractMethodCallFunction()
        {
            var mi = _testingType.GetMethod("CallFunction", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            Assert.IsNotNull(mi, "FunctionCalculator has CallFunction method");
            Assert.IsTrue(mi.IsAbstract, "CallFunction is abstract");
            Assert.IsTrue(mi.ReturnType.Equals(OperatingType), "CallFunction returns " + OperatingType.Name);
            Assert.AreEqual(mi.GetParameters().Length, 1, "CallFunction has one parameter");
            Assert.IsTrue(mi.GetParameters()[0].ParameterType.Equals(OperatingType), "CallFunction has one parameter in type of " + OperatingType.Name);
        }
    }
}
