using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyCalculator.Tests
{
    public class PlusCalculatorTest: BinaryCalculatorTestBase
    {
        public PlusCalculatorTest()
            : base(typeof(PlusCalculator))
        {

        }
        
        [TestMethod]
        public void MultiplyCalculator_CalcIsCorrect()
        {
            var piInner = GetSingleVaueCalculator(Value2);
            var piInner2 = GetSingleVaueCalculator(Value1);
            var calcMethod = GetAndVerifyCalcMethod(_testingType);
            var leftSetter = GetProperty(LeftPropertyName);
            var rightSetter = GetProperty(RightPropertyName);
            var @object = Activator.CreateInstance(_testingType);

            leftSetter.GetSetMethod().Invoke(@object, new object[] {piInner});
            rightSetter.GetSetMethod().Invoke(@object, new object[] { piInner2 });
            var result = calcMethod(@object);

            Assert.AreEqual((Value2 + Value1), result, Delta, "PlusCalculator calculates multiplication of two trees");
        }
    }
}
