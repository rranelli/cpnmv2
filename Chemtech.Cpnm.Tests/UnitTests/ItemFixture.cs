// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class ItemFixture
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
        public void CanAddItem()
        {
            var simpleItem = new Item {Name = "1112", UniqueName = "11123_1"};
            var repository = new ItemRepository();
            repository.Add(simpleItem);

            var fromDb = repository.GetById(simpleItem.Id);

            Assert.AreEqual(fromDb, simpleItem);
        }

        [Test]
        public void CanGetItemByName()
        {
            var repository = new ItemRepository();
            var simpleItem = repository.GetByName("P-101");
            Assert.IsNotNull(simpleItem);
        }

        [Test]
        public void CanUpdatePropValueInsideItem()
        {
            // TODO: This test tests too many things at once. Should refactor it.
            var repository = new ItemRepository();
            var proprepository = new PropertyRepository();
            var propvalrepo = new PropValueRepository();

            var complexItem = repository.GetByName("Complex");
            Assert.IsNotNull(complexItem);

            var property = proprepository.GetByName("Prop2");
            Assert.IsNotNull(property);

            var pval = complexItem.GetPropValue(property);
            Assert.IsNull(pval);

            pval = complexItem.GetNewPropValue(property);
            pval.Value = "112.34";

            complexItem.SetPropValue(pval);
            repository.Update(complexItem);

            var fromDb = repository.GetById(complexItem.Id);
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.GetPropValue(property), complexItem.GetPropValue(property));
        }
    }
}