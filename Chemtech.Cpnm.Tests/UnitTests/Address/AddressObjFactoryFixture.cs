// DimensionFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 10/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Addresses;
using Chemtech.CPNM.Model.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chemtech.CPNM.Tests.UnitTests.Address
{
    internal class AddressObjFactoryFixture
    {
        private IAddressFactory _addressObjfactory;
        private PropValue _mockedPropValue ;
        private UnitOfMeasure _mockedUnit;
        private Item _mockedItem;
        
        private Guid _itemid;
        private Guid _propid;
        private Guid _unitid;
        private PropValue.FormatType _formatType;

        [SetUp]
        public void SetUp()
        {
            _unitid = Guid.NewGuid();
            _itemid = Guid.NewGuid();
            _propid = Guid.NewGuid();
            _formatType = PropValue.FormatType.ValueAndUnit;

            _mockedItem = MockRepository.GenerateMock<Item>();
            _mockedItem.Expect(i => i.Id).Return(_itemid);

            _mockedUnit = MockRepository.GenerateMock<UnitOfMeasure>();
            _mockedUnit.Expect(uom => uom.Id).Return(_unitid);

            _mockedPropValue = MockRepository.GenerateMock<PropValue>();
            _mockedPropValue.Expect(pv => pv.ItemId).Return(_itemid);
            _mockedPropValue.Expect(pv => pv.GetProperty.Id).Return(_propid);
            _mockedPropValue.Expect(pv => pv.FormatedValue(_mockedUnit, _formatType)).Return("Right Value");

            var mockedItemRepo = MockRepository.GenerateMock<IItemRepository>();
            var mockedPropRepo = MockRepository.GenerateMock<IPropertyRepository>();
            
            var mockedUnitRepo = MockRepository.GenerateMock<IUnitOfMeasureRepository>();
            mockedUnitRepo.Expect(uomr => uomr.GetById(_unitid)).Return(_mockedUnit);

            var mockedPropValRepo = MockRepository.GenerateMock<IPropValueRepository>();
            mockedPropValRepo.Expect(pvr => pvr.GetByItemAndPropId(_itemid, _propid)).Return(_mockedPropValue);

            _addressObjfactory = new AddressObjFactory(mockedItemRepo,mockedPropValRepo,mockedUnitRepo,mockedPropRepo);
        }

        [Test]
        public void CanParsePropValAddressIntoObject() // Tests if the address factory can parse a string into the object with the correct behavior.
        {
            var valueRefAddressObj = new ValueRefAddress(_mockedPropValue, _mockedUnit, _formatType);

            string address = valueRefAddressObj.GetAddressString();
            var addressObj = _addressObjfactory.Create(address);

            Assert.AreEqual(addressObj.GetValue(), valueRefAddressObj.GetValue());
            Assert.AreEqual(address, valueRefAddressObj.GetAddressString());
        }

        [Test]
        public void CanParseAddressDefinerIntoValRefAddressObj()
        {
            var valRefAddressDefiner = new AddressDefiner
                                           {
                                               PropValue = _mockedPropValue,
                                               UnitOfMeasure = _mockedUnit,
                                               FormatType = _formatType
                                           };
            var realAddressObj = new ValueRefAddress(_mockedPropValue, _mockedUnit, _formatType);
            var addressObj = _addressObjfactory.Create(valRefAddressDefiner);

            Assert.AreEqual(realAddressObj.GetAddressString(), addressObj.GetAddressString());
            Assert.AreEqual(realAddressObj.GetValue(), addressObj.GetValue());
        }
    }
}