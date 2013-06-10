using CPNMv2.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace CPNMv2.Tests.UnitTests
{
    class PropValueFixture
    {
        private UnitOfMeasure _unit1;
        private UnitOfMeasure _unit2;
        private UnitOfMeasure _unit3;
        private Property _thisproperty;
        private PropValue _thispropvalue;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _unit1 = new UnitOfMeasure() { ConvFactor = 3, OffsetFactor = 1, Symbol = "Unit1" };
            _unit2 = new UnitOfMeasure() { ConvFactor = 2, Symbol = "Unit2" };
            _unit3 = new UnitOfMeasure() { ConvFactor = 0.3, OffsetFactor = 1, Symbol = "Unit3" };
        }

        [SetUp]
        public void SetUp()
        {
            var dimension = new Dimension() {Units = new UnitOfMeasure[] {_unit1, _unit2, _unit3}};
            _thisproperty = new Property() { Dimension = dimension, DefaultUnit = _unit3 };
            _thispropvalue = new PropValue { Property = _thisproperty, Value = "100" };
        }

        // Testes da camada de persistencia.
        //TODO: testes da camada de persistencia incorporando os valores corretos.

        // Testes de funcionalidade
        [Test]
        public void CannotConvertIfNotConvertible()
        {
            // substituindo o comportamento da PROPRIEDADE
            var mockedProperty = MockRepository.GenerateStub<Property>();
            mockedProperty.Stub(x => x.IsConvertible()).Return(false);

            var propValue = new PropValue() { Property = mockedProperty, Value = "112.2" };
            Assert.IsFalse(propValue.IsConvertible());
        }

        [Test]
        public void CannotConvertIfNotParseable()
        {
            // substituindo o comportamento da PROPRIEDADE
            var mockedProperty = MockRepository.GenerateStub<Property>();
            mockedProperty.Stub(x => x.IsConvertible()).Return(false);

            var propValue = new PropValue() { Property = mockedProperty, Value = "112.2" };
            Assert.IsFalse(propValue.IsConvertible());
        }

        [Test] // On IsConvertible call, must call Propertie member IsConvertibleMethod
        public void MustCallPropertyIsconvertible()
        {
            var mockedProperty = MockRepository.GenerateStub<Property>();
            mockedProperty.Expect(x => x.IsConvertible()).Return(true);

            var propValue = new PropValue { Property = mockedProperty };
            propValue.IsConvertible();
        }

        [Test] // must convert correctly
        public void CheckIsConvertible()
        {
            var mockedProperty = MockRepository.GenerateStub<Property>();
            mockedProperty.Expect(x => x.IsConvertible()).Return(true);

            var propValue = new PropValue { Property = mockedProperty, Value = "112.2" };
            Assert.IsTrue(propValue.IsConvertible());
        }

        [Test] // must convert correctly
        public void CanConvert()
        {

            var stringValue1 = _thispropvalue.FormatedValue(_unit1, PropValue.FormatType.Value);
            var stringValue2 = _thispropvalue.FormatedValue(_unit2, PropValue.FormatType.Value);

            Assert.AreEqual(stringValue1, "303");
            Assert.AreEqual(stringValue2, "200");
        }

        [Test]
        public void CanShowValueCorrectly()
        {

            var valueOnly1 = _thispropvalue.FormatedValue(_unit1, PropValue.FormatType.Value);
            var valueAndSymbol1 = _thispropvalue.FormatedValue(_unit1, PropValue.FormatType.ValueAndUnit);
            var symbolOnly1 = _thispropvalue.FormatedValue(_unit1, PropValue.FormatType.Unit);

            var valueOnly2 = _thispropvalue.FormatedValue(_unit2, PropValue.FormatType.Value);
            var valueAndSymbol2 = _thispropvalue.FormatedValue(_unit2, PropValue.FormatType.ValueAndUnit);
            var symbolOnly2 = _thispropvalue.FormatedValue(_unit2, PropValue.FormatType.Unit);

            Assert.AreEqual(valueOnly1, "303");
            Assert.AreEqual(valueAndSymbol1, "303 Unit1");
            Assert.AreEqual(symbolOnly1, "Unit1");

            Assert.AreEqual(valueOnly2, "200");
            Assert.AreEqual(valueAndSymbol2, "200 Unit2");
            Assert.AreEqual(symbolOnly2, "Unit2");
        }

        [Test]
        public void CanShowDefaultUnit()
        {
            var valueAndSymbolDefault = _thispropvalue.FormatedValue(_unit3, PropValue.FormatType.ValueAndUnit);
            var symbolDefault = _thispropvalue.FormatedValue(PropValue.FormatType.Unit);

            Assert.AreEqual(symbolDefault, "Unit3");
            Assert.AreEqual(valueAndSymbolDefault, "30.3 Unit3");
        }
    }
}