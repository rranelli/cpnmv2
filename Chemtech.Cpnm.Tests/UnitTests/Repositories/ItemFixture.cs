// ItemFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 06/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using Castle.Windsor.Installer;
using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NUnit.Framework;
using Configuration = NHibernate.Cfg.Configuration;

namespace Chemtech.CPNM.Tests.UnitTests.Repositories
{
    internal class ItemFixture
    {
        private Configuration _configuration;
        private IItemRepository _itemRepository;
        private IPropertyRepository _propertyRepository;
        private ITestHelper _testHelper;

        #region Fixture, Setup and Teardown config

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var container = DiResolver.Getcontainer();
            try { container.Install(FromAssembly.Named("Chemtech.CPNM.Tests")); }
            catch (Exception) { }
            _testHelper = container.Resolve<ITestHelper>();
            _configuration = _testHelper.MakeConfiguration();
        }

        [SetUp]
        public void SetUp()
        {
            _testHelper.SetUpDatabaseTestData(_configuration);
            _itemRepository = DiResolver.IocResolve<IItemRepository>();
            _propertyRepository = DiResolver.IocResolve<IPropertyRepository>();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _testHelper.TestTearDown(_configuration);
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

            complexItem.PropValues.Add(pval);
            _itemRepository.Update(complexItem);

            var fromDb = _itemRepository.GetById(complexItem.Id);
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.GetPropValue(property), complexItem.GetPropValue(property));
        }

        [Test]
        public void CanShareFromInsideItem()
        {
            var complexItem1 = _itemRepository.GetByName("Complex");
            var complexItem2 = _itemRepository.GetByName("Complex2");
            Assert.IsNotNull(complexItem1);
            Assert.IsNotNull(complexItem2);

            complexItem1.GetPropValue("Prop3").MakeShare(complexItem2.GetPropValue("Prop3"));
            _itemRepository.Update(complexItem1);

            complexItem2.GetPropValue("Prop3").Value = "11543423";
            _itemRepository.Update(complexItem2);

            var fromDb = _itemRepository.GetById(complexItem1.Id);
            Assert.AreEqual(fromDb.GetPropValue("Prop3").Value, "11543423");
        }
    }
}