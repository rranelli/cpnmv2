// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class ItemTypeGroupFixture
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
        public void CanAddItemTypeGroup()
        {
            var itemTypeGroup = new ItemTypeGroup();
            var repository = new ItemTypeGroupRepository();
            itemTypeGroup.Name = "Instrumentos";

            repository.Add(itemTypeGroup);
            var fromDb = repository.GetById(itemTypeGroup.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, itemTypeGroup);
            Assert.AreEqual(fromDb.Name, itemTypeGroup.Name);
        }

        [Test]
        public void CanRemoveItemTypeGroup()
        {
            var repository = new ItemTypeGroupRepository();
            var groupToBeRemoved = repository.GetByName("Eletrica");
            repository.Remove(groupToBeRemoved);
            Assert.IsNotNull(groupToBeRemoved);

            var fromDb = repository.GetById(groupToBeRemoved.Id);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateItemTypeGroup()
        {
            var repository = new ItemTypeGroupRepository();
            var groupToBeUpdated = repository.GetByName("Caldeiraria");
            groupToBeUpdated.Name = "Caldeiralove";
            repository.Update(groupToBeUpdated);

            var fromDb = repository.GetById(groupToBeUpdated.Id);
            var fromDbOld = repository.GetByName("Caldeiraria");

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, groupToBeUpdated);
            Assert.IsNull(fromDbOld);
        }
    }
}