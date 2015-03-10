using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyCalculator.Tests
{
    public abstract class CalcTestBase : TestBase
    {
        public CalcTestBase(Type typeToTest)
            :base (typeToTest)
        {

        }

        [TestMethod]
        public void ContainsCalcMethodInProperType()
        {
            GetAndVerifyCalcMethod(_testingType);
        }

    }
}
