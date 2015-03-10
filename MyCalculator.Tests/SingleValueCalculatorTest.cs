using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.Tests
{
    [TestClass]
    public class SingleValueCalculatorTest : CalcTestBase
    {
        private const string ValuePropertyName = "Value";
        public SingleValueCalculatorTest()
            : base(typeof(SingleValueCalculator))
        {

        }

        [TestMethod]
        public void SingleValueCalculator_IsNonAbstractClassImplmentingICalculator()
        {
            Assert.IsTrue(_testingType.IsClass, _testingType.Name + " must be class");
            Assert.IsFalse(_testingType.IsAbstract, _testingType.Name + " cannot be abstract");            
            Assert.IsTrue(_testingType.IsPublic, _testingType.Name + " must be public");
            Assert.IsTrue(CalculatorInterfaceType.IsAssignableFrom(_testingType), _testingType.Name + " must implment " + CalculatorInterfaceType.Name);            
        }
        
        [TestMethod]
        public void SingleValueCalculator_ConstructorSetsWhatValueGets()
        {
            var obj = GetSingleVaueCalculator(Value1);
            var valueProperty = GetValueProperty();

            valueProperty.GetSetMethod().Invoke(obj, new object[] { Value2 });
            var valueFromGetter = (double)valueProperty.GetGetMethod().Invoke(obj, null);

            Assert.AreEqual(Value2, valueFromGetter, Delta, "Getter and setter must operate on same value");            
        }               

        [TestMethod]
        public void SingleValueCalculator_ValueSetsWhatValueGets()
        {
            var obj = GetSingleVaueCalculator(Value1);
            var valueProperty = GetValueProperty();           

            var valueFromGetter = (double)valueProperty.GetGetMethod().Invoke(obj, null);

            Assert.AreEqual(Value1, valueFromGetter, Delta, "Constructor, getter and setter must operate on same value");
        }

        [TestMethod]
        public void SingleValueCalculator_CalcReturnsWhatWasSet()
        {
            var obj = GetSingleVaueCalculator(Value2);
            var calc = GetAndVerifyCalcMethod(_testingType);

            var calculatedValue = calc(obj);

            Assert.AreEqual(Value2, calculatedValue, Delta, "Calc returns value set by constructor or setter");
        }

        private System.Reflection.PropertyInfo GetValueProperty()
        {
            return GetProperty(ValuePropertyName);
        }
               
    }
}
