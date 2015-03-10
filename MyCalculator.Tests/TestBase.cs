using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MyCalculator.Tests
{
    public abstract class TestBase
    {
        protected const double Delta = 0.1;
        protected const string CalcMethodName = "Calc";
        protected const string InnerCalculatorPropertyName = "InnerCalculator";
        protected const string LeftPropertyName = "Left";
        protected const string RightPropertyName = "Right";
        protected static readonly Type OperatingType = typeof(double);
        protected static readonly Type CalculatorInterfaceType = typeof(ICalculator);
        protected static readonly double Value1 = Math.PI;
        protected static readonly double Value2 = Math.E;
        
        protected readonly Type _testingType;

        protected TestBase(Type typeToTest)
        {
            _testingType = typeToTest;
        }

        protected static Func<object, double> GetAndVerifyCalcMethod(Type tc)
        {
            var mi = GetCalcMethod(tc);
            
            if (mi.ReturnType != OperatingType)
            {
                Assert.Fail(
                    string.Format("{0} method must return values in type of {1}",
                        CalcMethodName, OperatingType.Name));
            }

            if (mi.GetParameters().Length != 0)
            {
                Assert.Fail(string.Format("{0} method cannot have any parameters", 
                    CalcMethodName));
            }

            return new Func<object, double>(obj => (double)mi.Invoke(obj, null));
        }

        protected static MethodInfo GetCalcMethod(Type tc)
        {
            return tc.GetMethod(CalcMethodName, BindingFlags.Public | BindingFlags.Instance);
        }
                
        protected static object GetSingleVaueCalculator(double value)
        {
            var singleValueType = typeof(SingleValueCalculator);
            var constructor = GetConstructor(singleValueType, OperatingType);

            return constructor.Invoke(new object[] { value });
        }

        protected static ConstructorInfo GetConstructor(Type singleValueType, Type parameterType)
        {
            var constructor = singleValueType.GetConstructor(new Type[] { parameterType });

            if (constructor == null)
            {
                Assert.Fail(
                    string.Format("{0} does not contain parameter with type of {1}",
                        singleValueType.Name, parameterType.Name));
            }

            return constructor;
        }

        protected PropertyInfo GetProperty(string propertyName)
        {
            var valueProperty = _testingType.GetProperty(propertyName, BindingFlags.Public|BindingFlags.Instance|BindingFlags.GetProperty|BindingFlags.SetProperty);

            if (valueProperty == null)
            {
                Assert.Fail(string.Format("{0} does not contain property with name {1}", 
                    _testingType.Name, propertyName));
            }

            return valueProperty;
        }

        protected void TestProperty(string propertyName, Type expectedType)
        {
            var property = GetProperty(propertyName);

            Assert.IsTrue(expectedType.Equals(property.PropertyType),
                string.Format("{0} property is in type of {1}", propertyName, expectedType.Name));
        }
    }
}
