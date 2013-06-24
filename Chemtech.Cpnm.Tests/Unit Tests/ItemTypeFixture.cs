// ItemTypeFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 11/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Collections.Generic;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class ItemTypeFixture
    {
        private Configuration _configuration;

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
            var repository = new ItemTypeRepository();
            itemType.Name = "Tanque";

            repository.Add(itemType);
            ItemType fromDb = repository.GetById(itemType.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, itemType);
            Assert.AreEqual(fromDb.Name, itemType.Name);
        }

        [Test]
        public void CanRemoveItemType()
        {
            var repository = new ItemTypeRepository();
            ItemType typeToBeRemoved = repository.GetByName("Transmissor");
            repository.Remove(typeToBeRemoved);
            Assert.IsNotNull(typeToBeRemoved);

            ItemType fromDb = repository.GetById(typeToBeRemoved.Id);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateItemType()
        {
            var repository = new ItemTypeRepository();
            ItemType typeToBeUpdated = repository.GetByName("Bomba");
            typeToBeUpdated.Name = "Bombalove";
            repository.Update(typeToBeUpdated);

            ItemType fromDb = repository.GetById(typeToBeUpdated.Id);
            ItemType fromDbOld = repository.GetByName("Bomba");

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

            var propRepo = new PropertyRepository();
            propRepo.Add(prop2);
            propRepo.Add(prop3);

            var newItemType = new ItemType
                                  {
                                      Name = "NovoTipo",
                                      ValidXrefs = new[]
                                                       {
                                                           new Xref {Property = prop2},
                                                           new Xref {Property = prop3}
                                                       }
                                  };

            var repository = new ItemTypeRepository();
            repository.Add(newItemType);
        }

        [Test]
        public void CanGetWholeGroup()
        {
            var itemgroupRepo = new ItemTypeGroupRepository();
            var itemtyperepo = new ItemTypeRepository();

            var theGroup = new[]
                               {
                                   itemtyperepo.GetByName("Tanque"),
                                   itemtyperepo.GetByName("Transmissor"),
                                   itemtyperepo.GetByName("Bomba"),
                                   itemtyperepo.GetByName("Linha"),
                                   itemtyperepo.GetByName("Cantoneira"),
                               };


            ItemTypeGroup fromDbGroup = itemgroupRepo.GetByName("Estaticos");
            Assert.IsNotNull(fromDbGroup);

            ICollection<ItemType> fromDb = itemtyperepo.GetByGroup(fromDbGroup);
            Assert.IsNotNull(fromDb);

            foreach (ItemType thisItemType in theGroup)
            {
                Assert.IsTrue(fromDb.Contains(thisItemType));
            }
        }
    }
}