// DimensionFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 10/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System;
using Chemtech.CPNM.Model.Domain;
using Chemtech.Cpnm.Data.Addresses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chemtech.CPNM.Tests.UnitTests.Address
{
    internal class ValueRefAddressFixture
    {
        private Guid _unitid;
        private Guid _itemid;
        private Guid _propid;
        private PropValue.FormatType _formatType;
        private UnitOfMeasure _mockedUnit;
        private PropValue _mockedPropValue;
        private Property _mockedProperty;

        [SetUp]
        public void SetUp()
        {
            _unitid = Guid.NewGuid();
            _itemid = Guid.NewGuid();
            _propid = Guid.NewGuid();
            _formatType = PropValue.FormatType.ValueAndUnit;

            _mockedUnit = MockRepository.GenerateMock<UnitOfMeasure>();
            _mockedUnit.Expect(uom => uom.Id).Return(_unitid);

            _mockedProperty = MockRepository.GenerateMock<Property>();
            _mockedProperty.Expect(p => p.DefaultUnit).Return(_mockedUnit);
            _mockedProperty.Expect(p => p.Id).Return(_propid);

            _mockedPropValue = MockRepository.GenerateMock<PropValue>();
            _mockedPropValue.Expect(pv => pv.ItemId).Return(_itemid);
            _mockedPropValue.Expect(pv => pv.GetProperty).Return(_mockedProperty);
            _mockedPropValue.Expect(pv => pv.FormatedValue(_mockedUnit, _formatType)).Return("Right Value");
        }

        [Test]
        public void ShowsCorrectValue() // Testa se o FormatedValue eh chamado.
        {
            var result = new ValueRefAddress(_mockedPropValue, _mockedUnit, _formatType).GetValue();
            Assert.AreEqual(result, "Right Value");
        }

        [Test]
        public void AddressContainsAllIds()
        {
            var address = new ValueRefAddress(_mockedPropValue, _mockedUnit, _formatType).GetAddressString();
            Assert.IsTrue(address.Contains(_itemid.ToString()));
            Assert.IsTrue(address.Contains(_unitid.ToString()));
            Assert.IsTrue(address.Contains(_propid.ToString()));
            Assert.IsTrue(address.Contains(_formatType.ToString()));
        }

        [Test]
        public void AddressContainsDefaultUnitId()
        {
            var address = new ValueRefAddress(_mockedPropValue, null, _formatType).GetAddressString();
            
            Assert.IsTrue(address.Contains(_itemid.ToString()));
            Assert.IsTrue(address.Contains(_unitid.ToString()));
            Assert.IsTrue(address.Contains(_propid.ToString()));
            Assert.IsTrue(address.Contains(_formatType.ToString()));
        }
    }
}