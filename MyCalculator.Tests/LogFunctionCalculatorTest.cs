using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyCalculator.Tests
{
    [TestClass]
    public class LogFunctionCalculatorTest: FunctionCalculatorTestBase
    {
        public LogFunctionCalculatorTest()
            : base(typeof(LogFunctionCalculator))
        {

        }
        
        [TestMethod]
        public void LogFunctionCalculator_CalcIsCorrect()
        {
            var piInner = GetSingleVaueCalculator(Value2);
            var ctor = GetConstructor(_testingType, CalculatorInterfaceType);
            var calcMethod = GetAndVerifyCalcMethod(_testingType);
            var @object = ctor.Invoke(new object[] { piInner });

            var result = calcMethod(@object);

            Assert.AreEqual(Math.Log(Value2), result, Delta, "LogFunctionCalculator calculates sinuses");
        }
    }
}
