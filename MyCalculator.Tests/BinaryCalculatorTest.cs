using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MyCalculator.Tests
{
    [TestClass]
    public class BinaryCalculatorTest: CalcTestBase
    {
        public BinaryCalculatorTest()
            : base(typeof(BinaryCalculator))
        {

        }

        [TestMethod]
        public void BinaryCalculator_IsPublicAbstractClass()
        {
            Assert.IsTrue(_testingType.IsClass, string.Format("{0} is class", _testingType.Name));
            Assert.IsTrue(_testingType.IsPublic, string.Format("{0} is public", _testingType.Name));
            Assert.IsTrue(_testingType.IsAbstract, string.Format("{0} is abstract class", _testingType.Name));
        }


        [TestMethod]
        public void BinaryCalculator_ImplementsIBinaryCalculator()
        {
            var unaryCalcInterface = _testingType.GetInterfaces().FirstOrDefault(pi => pi.Equals(typeof(IBinaryCalculator)));

            Assert.IsNotNull(unaryCalcInterface, string.Format("{0} implements IBinaryCalculator", _testingType.Name));
        }

        [TestMethod]
        public void BinaryCalculator_HasProtectedAbstractMethodCall()
        {
            var mi = _testingType.GetMethod(CalcMethodName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            Assert.IsNotNull(mi, "BinaryCalculator has Calc method");
            Assert.IsTrue(mi.IsAbstract, "Calc is abstract");
            Assert.IsTrue(mi.ReturnType.Equals(OperatingType), "Calc returns " + OperatingType.Name);
            Assert.AreEqual(mi.GetParameters().Length, 0, "CallFunction does not have parameters");
        }
    }
}
