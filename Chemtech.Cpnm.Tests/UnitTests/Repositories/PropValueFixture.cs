// PropValueFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 06/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using System.Linq;
<<<<<<< HEAD
=======
using Chemtech.CPNM.BR;
>>>>>>> 5267e163de70384897acb9bb67abbbd054ebd0a7
using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chemtech.CPNM.Tests.UnitTests.Repositories
{
    internal class PropValueFixture
    {
        private Configuration _configuration;
        private Xref _newXref;
        private Guid _parentId1;
        private Guid _parentId2;
        private PropValue _propValue1;
        private PropValue _propValue2;
        private Property _thisproperty;
        private PropValue _thispropvalue;
        private UnitOfMeasure _unit1;
        private UnitOfMeasure _unit2;
        private UnitOfMeasure _unit3;

        private IDimensionRepository _dimensionRepository;
        private IItemRepository _itemRepository;
        private IPropertyRepository _propertyRepository;
        private IXrefRepository _xrefRepository;
        private IPropValueRepository _propValueRepository;
        private ITestHelper _testHelper;

        #region Fixture, Setup and Teardown config

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _testHelper = DiResolver.IocResolve<ITestHelper>();
            _configuration = _testHelper.MakeConfiguration();

            _dimensionRepository = DiResolver.IocResolve<IDimensionRepository>();
            _itemRepository = DiResolver.IocResolve<IItemRepository>();
            _propertyRepository = DiResolver.IocResolve<IPropertyRepository>();
            _xrefRepository = DiResolver.IocResolve<IXrefRepository>();
            _propValueRepository = DiResolver.IocResolve<IPropValueRepository>();
        }

        [SetUp]
        public void SetUp()
        {
            _testHelper.SetUpDatabaseTestData(_configuration);

            var dimension = _dimensionRepository.GetByName("Vazao");
            _unit1 = dimension.Units.ToList().SingleOrDefault(x => x.Name == "Unit1");
            _unit2 = dimension.Units.ToList().SingleOrDefault(x => x.Name == "Unit2");
            _unit3 = dimension.Units.ToList().SingleOrDefault(x => x.Name == "Unit3");

            _thisproperty = new Property {Dimension = dimension, DefaultUnit = _unit3};
            _parentId1 = _itemRepository.GetAll().SingleOrDefault(i => i.Name == "Complex").Id;
            _parentId2 = _itemRepository.GetAll().SingleOrDefault(i => i.Name == "P-101").Id;
            _thispropvalue = new PropValue {Xref = _newXref, Value = "100", ItemId = _parentId1};

            _newXref = new Xref {Property = _thisproperty};
            _propertyRepository.Add(_thisproperty);
            _xrefRepository.Add(_newXref);

            _propValue1 = new PropValue {Value = "new value1", Xref = _newXref, ItemId = _parentId1};
            _propValue2 = new PropValue {Value = "A Hell Of A Value!", Xref = _newXref, ItemId = _parentId2};
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _testHelper.TestTearDown(_configuration);
        }

        #endregion

        // Testes da camada de persistencia.
        [Test]
        public void CanAddPropValue()
        {
            var propValueToAdd = new PropValue {Value = "new value", Xref = _newXref, ItemId = _parentId1};

            _propValueRepository.Add(propValueToAdd);
            var fromDb = _propValueRepository.GetById(propValueToAdd.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, propValueToAdd);
        }

        [Test]
        public void CanAddSharedValue()
        {
            _propValueRepository.Add(_propValue1);
            _propValueRepository.Add(_propValue2);

            var fromDb1 = _propValueRepository.GetById(_propValue1.Id);
            var fromDb2 = _propValueRepository.GetById(_propValue2.Id);

            Assert.AreNotEqual(fromDb1.Value, fromDb2.Value);

            _propValue1.MakeShare(_propValue2);
            _propValueRepository.Update(_propValue1);

            fromDb1 = _propValueRepository.GetById(_propValue1.Id);
            fromDb2 = _propValueRepository.GetById(_propValue2.Id);

            Assert.AreEqual(fromDb1.Value, fromDb2.Value);
        }

        [Test]
        public void ShareUpdatesCorrectly()
        {

            _propValue1.MakeShare(_propValue2);
            _propValueRepository.Add(_propValue1);
            _propValueRepository.Add(_propValue2);

            _propValue2.Value = "Tada! A new value";
            _propValueRepository.Update(_propValue2);

            var fromDb1 = _propValueRepository.GetById(_propValue1.Id);
            var fromDb2 = _propValueRepository.GetById(_propValue2.Id);

            Assert.AreEqual(fromDb1.Value, fromDb2.Value);
            Assert.AreNotEqual(fromDb1.Id, fromDb2.Id);
        }

        [Test]
        public void CanRemovePropValue()
        {
            _propValueRepository.Add(_propValue1);
            Assert.IsNotNull(_propValueRepository.GetById(_propValue1.Id));

            _propValueRepository.Remove(_propValue1);
            Assert.IsNull(_propValueRepository.GetById(_propValue1.Id));
        }

        [Test]
        public void BreaksShareCorrecly()
        {
            _propValue1.MakeShare(_propValue2);
            var propValueSharedWith2 = _propValue1;

            _propValueRepository.Add(_propValue2);
            _propValueRepository.Add(propValueSharedWith2);

            var fromDbShared1 = _propValueRepository.GetById(propValueSharedWith2.Id);
            var fromDbShared2 = _propValueRepository.GetById(propValueSharedWith2.Id);

            Assert.AreEqual(fromDbShared1.Value, fromDbShared2.Value);

            propValueSharedWith2.BreakShare(_propValue2);
            propValueSharedWith2.Value = "I BROKE FREE!!";
            _propValueRepository.Update(propValueSharedWith2);

            var fromDbNotSharedAnymore = _propValueRepository.GetById(propValueSharedWith2.Id);
            var fromDb2 = _propValueRepository.GetById(_propValue2.Id);

            Assert.AreNotEqual(fromDb2.Value, fromDbNotSharedAnymore.Value);
            Assert.AreNotEqual(fromDb2, fromDbNotSharedAnymore);
        }

        // ###########################
        // Testes de funcionalidade
        [Test]
        public void CanShare()
        {
            _propValue1.MakeShare(_propValue2);
            Assert.AreEqual(_propValue1.Value, _propValue2.Value);
        }


        [Test]
        public void CannotConvertIfNotConvertible()
        {
            var mockedProperty = MockRepository.GenerateStub<Property>();
            mockedProperty.Stub(x => x.IsConvertible()).Return(false);

            var propValue = new PropValue {Xref = new Xref {Property = mockedProperty}, Value = "112.2"};
            Assert.IsFalse(propValue.IsConvertible());
        }

        [Test]
        public void CannotConvertIfValueIsNull()
        {
            var nullValue = new PropValue();
            Assert.IsNull(nullValue.Value);
            Assert.False(nullValue.IsConvertible());
        }

        [Test]
        public void CannotConvertIfXrefIsNull()
        {
            var nullProp = new PropValue {Value = "112", Xref = null};
            Assert.False(nullProp.IsConvertible());
        }

        [Test]
        public void CannotConvertIfNotParseable()
        {
            var mockedProperty = MockRepository.GenerateStub<Property>();
            mockedProperty.Stub(x => x.IsConvertible()).Return(false);

            var propValue = new PropValue {Xref = new Xref {Property = mockedProperty}, Value = "112.2"};
            Assert.IsFalse(propValue.IsConvertible());
        }

        [Test] // On IsConvertible call, must call Propertie member IsConvertibleMethod
        public void MustCallPropertyIsconvertible()
        {
            var mockedProperty = MockRepository.GenerateStub<Property>();
            mockedProperty.Expect(x => x.IsConvertible()).Return(true);

            var propValue = new PropValue {Xref = new Xref {Property = mockedProperty}};
            propValue.IsConvertible();
        }

        [Test] // must convert correctly
        public void CheckIsConvertible()
        {
            var mockedProperty = MockRepository.GenerateStub<Property>();
            mockedProperty.Expect(x => x.IsConvertible()).Return(true);

            var propValue = new PropValue {Xref = new Xref {Property = mockedProperty}, Value = "112.2"};
            Assert.IsTrue(propValue.IsConvertible());
        }

        [Test] // must convert correctly
        public void CanConvert()
        {
            string stringValue1 = _thispropvalue.FormatedValue(_unit1, PropValue.FormatType.Value);
            string stringValue2 = _thispropvalue.FormatedValue(_unit2, PropValue.FormatType.Value);

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