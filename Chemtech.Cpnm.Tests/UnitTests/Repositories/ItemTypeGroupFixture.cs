﻿// ItemTypeGroupFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 06/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Presentation;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class ItemTypeGroupFixture
    {
        private Configuration _configuration;
        private IItemTypeGroupRepository _itemTypeGroupRepository;
        private ITestHelper _testHelper;

        #region Fixture, Setup and Teardown config

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _testHelper = DiResolver.IocResolve<ITestHelper>();
            _configuration = _testHelper.MakeConfiguration();
        }

        [SetUp]
        public void SetUp()
        {
            _itemTypeGroupRepository = DiResolver.IocResolve<IItemTypeGroupRepository>();
            _testHelper.SetUpDatabaseTestData(_configuration);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _testHelper.TestTearDown(_configuration);
        }

        #endregion

        [Test]
        public void CanAddItemTypeGroup()
        {
            var itemTypeGroup = new ItemTypeGroup {Name = "Instrumentos"};

            _itemTypeGroupRepository.Add(itemTypeGroup);
            var fromDb = _itemTypeGroupRepository.GetById(itemTypeGroup.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, itemTypeGroup);
            Assert.AreEqual(fromDb.Name, itemTypeGroup.Name);
        }

        [Test]
        public void CanRemoveItemTypeGroup()
        {
            ItemTypeGroup groupToBeRemoved = _itemTypeGroupRepository.GetByName("Eletrica");
            _itemTypeGroupRepository.Remove(groupToBeRemoved);
            Assert.IsNotNull(groupToBeRemoved);

            ItemTypeGroup fromDb = _itemTypeGroupRepository.GetById(groupToBeRemoved.Id);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateItemTypeGroup()
        {
            ItemTypeGroup groupToBeUpdated = _itemTypeGroupRepository.GetByName("Caldeiraria");
            groupToBeUpdated.Name = "Caldeiralove";
            _itemTypeGroupRepository.Update(groupToBeUpdated);

            ItemTypeGroup fromDb = _itemTypeGroupRepository.GetById(groupToBeUpdated.Id);
            ItemTypeGroup fromDbOld = _itemTypeGroupRepository.GetByName("Caldeiraria");

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, groupToBeUpdated);
            Assert.IsNull(fromDbOld);
        }
    }
}
