// DimensionFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 10/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System;
using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.AddressHandling.Addresses;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chemtech.CPNM.Tests.UnitTests.Address
{
    internal class AddressObjFactoryFixture
    {
        // Todo: Nao da pra testar a addressobjfactory pois ela faz fetch direto do banco de dados. Nao da pra mockar parse.
        private IAddressFactory _addressObjfactory;
        private PropValue _mockedPropValue ;
        private Property _mockedProperty ;
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

            _mockedUnit = MockRepository.GenerateMock<UnitOfMeasure>();
            _mockedUnit.Expect(uom => uom.Id).Return(_unitid);

            _mockedProperty = MockRepository.GenerateMock<Property>();
            _mockedProperty.Expect(prop => prop.Id).Return(_propid);

            _mockedPropValue = MockRepository.GenerateMock<PropValue>();
            _mockedPropValue.Expect(pv => pv.ItemId).Return(_itemid);
            _mockedPropValue.Expect(pv => pv.GetProperty).Return(_mockedProperty);
            _mockedPropValue.Expect(pv => pv.FormatedValue(_mockedUnit, _formatType)).Return("Right Value");
            _mockedPropValue.Expect(pv => pv.Value).Return("Right Value");

            _mockedItem = MockRepository.GenerateMock<Item>();
            _mockedItem.Expect(i => i.Id).Return(_itemid);
            _mockedItem.Expect(i => i.GetPropValue(_mockedProperty)).Return(_mockedPropValue);

            var mockedItemRepo = MockRepository.GenerateMock<IItemRepository>();
            mockedItemRepo.Expect(mir => mir.GetById(_mockedItem.Id)).Return(_mockedItem);

            var mockedPropRepo = MockRepository.GenerateMock<IPropertyRepository>();
            mockedPropRepo.Expect(mpr => mpr.GetById(_mockedProperty.Id)).Return(_mockedProperty);
            
            var mockedUnitRepo = MockRepository.GenerateMock<IUnitOfMeasureRepository>();
            mockedUnitRepo.Expect(uomr => uomr.GetById(_unitid)).Return(_mockedUnit);

            _addressObjfactory = new AddressObjFactory(mockedItemRepo,mockedUnitRepo,mockedPropRepo);
        }

        [Test]
        public void CanParsePropValAddressIntoObject() // Tests if the address factory can parse a string into the object with the correct behavior.
        {
            var valueRefAddressObj = new ValueRefAddress(_mockedItem, _mockedProperty, _mockedUnit, _formatType);

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
                                               Item = _mockedItem,
                                               Property = _mockedProperty,
                                               UnitOfMeasure = _mockedUnit,
                                               FormatType = _formatType
                                           };
            var realAddressObj = new ValueRefAddress(_mockedItem, _mockedProperty, _mockedUnit, _formatType);
            var addressObj = _addressObjfactory.Create(valRefAddressDefiner);

            Assert.AreEqual(realAddressObj.GetAddressString(), addressObj.GetAddressString());
            Assert.AreEqual(realAddressObj.GetValue(), addressObj.GetValue());
        }
    }
}