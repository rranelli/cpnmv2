// ItemFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 06/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using Chemtech.CPNM.BR;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class ItemFixture
    {
        private Configuration _configuration;
        private IItemRepository _itemRepository;
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
            _itemRepository = new CpnmStart().IocResolve<IItemRepository>();
            _propertyRepository = new CpnmStart().IocResolve<IPropertyRepository>();
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
            _itemRepository.Add(simpleItem);

            var fromDb = _itemRepository.GetById(simpleItem.Id);

            Assert.AreEqual(fromDb, simpleItem);
        }

        [Test]
        public void CanGetItemByName()
        {
            var simpleItem = _itemRepository.GetByName("P-101");
            Assert.IsNotNull(simpleItem);
        }

        [Test]
        public void CanUpdatePropValueInsideItem()
        {
            // TODO: This test tests too many things at once. Should refactor it.
            var complexItem = _itemRepository.GetByName("Complex");
            Assert.IsNotNull(complexItem);

            var property = _propertyRepository.GetByName("Prop2");
            Assert.IsNotNull(property);

            var pval = complexItem.GetPropValue(property);
            Assert.IsNull(pval);

            pval = complexItem.GetNewPropValue(property);
            pval.Value = "112.34";

            complexItem.SetPropValue(pval);
            _itemRepository.Update(complexItem);

            var fromDb = _itemRepository.GetById(complexItem.Id);
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.GetPropValue(property), complexItem.GetPropValue(property));
        }

        [Test]
        public void CanShareFromInsideItem()
        {
            var repository = new ItemRepository();

            var complexItem1 = repository.GetByName("Complex");
            var complexItem2 = repository.GetByName("Complex2");
            Assert.IsNotNull(complexItem1);
            Assert.IsNotNull(complexItem2);

            complexItem1.GetPropValue("Prop3").MakeShare(complexItem2.GetPropValue("Prop3"));
            repository.Update(complexItem1);

            complexItem2.GetPropValue("Prop3").Value = "11543423";
            repository.Update(complexItem2);

            var fromDb = repository.GetById(complexItem1.Id);
            Assert.AreEqual(fromDb.GetPropValue("Prop3").Value, "11543423");
        }
    }
}