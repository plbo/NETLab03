using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyCalculator.Tests
{
    [TestClass]
    public class SinusFunctionCalculatorTest : FunctionCalculatorTestBase
    {
        public SinusFunctionCalculatorTest()
            : base(typeof(SinusFunctionCalculator))
        {

        }
        
        [TestMethod]
        public void SinusFunctionCalculator_CalcIsCorrect()
        {
            var piInner = GetSingleVaueCalculator(Value1);
            var ctor = GetConstructor(_testingType, CalculatorInterfaceType);
            var calcMethod = GetAndVerifyCalcMethod(_testingType);
            var @object = ctor.Invoke(new object[] { piInner });

            var result = calcMethod(@object);

            Assert.AreEqual(Math.Sin(Value1), result, Delta, "SinusFunctionCalculator calculates sinuses");
        }
    }
}
