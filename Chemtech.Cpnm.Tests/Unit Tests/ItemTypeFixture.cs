// ItemTypeFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 11/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Collections.Generic;
using Chemtech.CPNM.BR;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class ItemTypeFixture
    {
        private Configuration _configuration;
        private IItemTypeRepository _itemTypeRepository;
        private IItemTypeGroupRepository _itemTypeGroupRepository;
        private IPropertyRepository _propertyRepository;

        #region Fixture, Setup and Teardown config

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new TestHelper().MakeConfiguration();
        }

        [SetUp]
        public void SetUp()
        {
            new TestHelper().SetUpDatabaseTestData(_configuration);
            _itemTypeRepository = new CpnmStart().IocResolve<IItemTypeRepository>();
            _propertyRepository = new CpnmStart().IocResolve<IPropertyRepository>();
            _itemTypeGroupRepository = new CpnmStart().IocResolve<IItemTypeGroupRepository>();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            new TestHelper().TestTearDown(_configuration);
        }

        #endregion

        [Test]
        public void CanAddItemType()
        {
            var itemType = new ItemType();
            itemType.Name = "Tanque";

            _itemTypeRepository.Add(itemType);
            ItemType fromDb = _itemTypeRepository.GetById(itemType.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, itemType);
            Assert.AreEqual(fromDb.Name, itemType.Name);
        }

        [Test]
        public void CanRemoveItemType()
        {
            ItemType typeToBeRemoved = _itemTypeRepository.GetByName("Transmissor");
            _itemTypeRepository.Remove(typeToBeRemoved);
            Assert.IsNotNull(typeToBeRemoved);

            ItemType fromDb = _itemTypeRepository.GetById(typeToBeRemoved.Id);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateItemType()
        {
            ItemType typeToBeUpdated = _itemTypeRepository.GetByName("Bomba");
            typeToBeUpdated.Name = "Bombalove";
            _itemTypeRepository.Update(typeToBeUpdated);

            ItemType fromDb = _itemTypeRepository.GetById(typeToBeUpdated.Id);
            ItemType fromDbOld = _itemTypeRepository.GetByName("Bomba");

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, typeToBeUpdated);
            Assert.IsNull(fromDbOld);
        }

        /*[Test]
        public void CannotUpdateGroup()
        {
            var repository = new ItemTypeRepository();
            var typeToUpdateGroup = repository.GetByName("Bomba");
            var newItemTypeGroup = new ItemTypeGroup() { Name = "Rotativos" };
            typeToUpdateGroup.ItemTypeGroup = newItemTypeGroup;
            //var mockedRepo =  TODO: Criar um repositorio mockado que faz um assert da exception;
            mockedRepo.Update(typeToUpdateGroup);

            var fromDb = repository.GetById(typeToUpdateGroup.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreNotEqual(fromDb.ItemTypeGroup, typeToUpdateGroup.ItemTypeGroup);
        }*/

        [Test]
        public void CanUpdateValidXrefs()
        {
            var prop2 = new Property {Name = "Prop2"};
            var prop3 = new Property {Name = "Prop3"};

            _propertyRepository.Add(prop2);
            _propertyRepository.Add(prop3);

            var newItemType = new ItemType
                                  {
                                      Name = "NovoTipo",
                                      ValidXrefs = new[]
                                                       {
                                                           new Xref {Property = prop2},
                                                           new Xref {Property = prop3}
                                                       }
                                  };

            _itemTypeRepository.Add(newItemType);
        }

        [Test]
        public void CanGetWholeGroup()
        {
            var theGroup = new[]
                               {
                                   _itemTypeRepository.GetByName("Tanque"),
                                   _itemTypeRepository.GetByName("Transmissor"),
                                   _itemTypeRepository.GetByName("Bomba"),
                                   _itemTypeRepository.GetByName("Linha"),
                                   _itemTypeRepository.GetByName("Cantoneira"),
                               };


            var fromDbGroup = _itemTypeGroupRepository.GetByName("Estaticos");
            Assert.IsNotNull(fromDbGroup);

            var fromDb = _itemTypeRepository.GetByGroup(fromDbGroup);
            Assert.IsNotNull(fromDb);

            foreach (var thisItemType in theGroup)
                Assert.IsTrue(fromDb.Contains(thisItemType));
        }
    }
}