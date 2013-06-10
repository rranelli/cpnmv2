using CPNMv2.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace CPNMv2.Tests.UnitTests
{
    class PropValueFixture
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
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
            var unit1 = new UnitOfMeasure() { ConvFactor = 3, OffsetFactor = 1, Symbol = "Unit1" };
            var unit2 = new UnitOfMeasure() { ConvFactor = 2, Symbol = "Unit2" };

            var thisProperty = new Property() { ValidUnits = new UnitOfMeasure[] { unit1, unit2 } };
            var propValue = new PropValue { Property = thisProperty, Value = "100" };

            var stringValue1 = propValue.GetFormatedValue(unit1, PropValue.FormatType.Value);
            var stringValue2 = propValue.GetFormatedValue(unit2, PropValue.FormatType.Value);

            Assert.AreEqual(stringValue1, "303");
            Assert.AreEqual(stringValue2, "200");
        }

        [Test]
        public void CanShowValueCorrectly()
        {
            var unit1 = new UnitOfMeasure() { ConvFactor = 1, Symbol = "Unit1" };
            var unit2 = new UnitOfMeasure() { ConvFactor = 1, Symbol = "Unit2" };
            var thisProperty = new Property() { ValidUnits = new UnitOfMeasure[] { unit1, unit2 } };
            var propValue = new PropValue { Property = thisProperty, Value = "100" };

            var valueOnly1 = propValue.GetFormatedValue(unit1, PropValue.FormatType.Value);
            var valueAndSymbol1 = propValue.GetFormatedValue(unit1, PropValue.FormatType.ValueAndUnit);
            var symbolOnly1 = propValue.GetFormatedValue(unit1, PropValue.FormatType.Unit);

            var valueOnly2 = propValue.GetFormatedValue(unit2, PropValue.FormatType.Value);
            var valueAndSymbol2 = propValue.GetFormatedValue(unit2, PropValue.FormatType.ValueAndUnit);
            var symbolOnly2 = propValue.GetFormatedValue(unit2, PropValue.FormatType.Unit);

            Assert.AreEqual(valueOnly1, "100");
            Assert.AreEqual(valueAndSymbol1, "100 Unit1");
            Assert.AreEqual(symbolOnly1, "Unit1");

            Assert.AreEqual(valueOnly2, "100");
            Assert.AreEqual(valueAndSymbol2, "100 Unit2");
            Assert.AreEqual(symbolOnly2, "Unit2");
        }
    }
}