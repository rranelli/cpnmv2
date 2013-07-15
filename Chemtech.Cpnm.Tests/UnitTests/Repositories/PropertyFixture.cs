// PropertyFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 10/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Presentation;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests.Repositories
{
    internal class PropertyFixture
    {
        private Configuration _configuration;
        private IPropertyRepository _propertyRepository;
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
            _testHelper.SetUpDatabaseTestData(_configuration);
            _propertyRepository = DiResolver.IocResolve<IPropertyRepository>();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _testHelper.TestTearDown(_configuration);
        }

        #endregion

        [Test]
        public void CanAddProperty()
        {
            var property = new Property {Name = "Prop115"};

            _propertyRepository.Add(property);
            var fromDb = _propertyRepository.GetById(property.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.Id, property.Id);
        }

        [Test]
        public void CanRemoveProperty()
        {
            _propertyRepository.Add(new Property {Name = "Ima gonna be remuvd"});
            var propertyToRemove = _propertyRepository.GetByName("Ima gonna be remuvd");
            Assert.IsNotNull(propertyToRemove);

            _propertyRepository.Remove(propertyToRemove);
            var fromDb = _propertyRepository.GetById(propertyToRemove.Id);

            Assert.IsNotNull(propertyToRemove);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateProperty()
        {
            var propertyToUpdate = _propertyRepository.GetByName("Prop1");
            propertyToUpdate.Name = "Prop1-love";
            _propertyRepository.Update(propertyToUpdate);

            var fromDbOld = _propertyRepository.GetByName("Prop1");
            var fromDb = _propertyRepository.GetById(propertyToUpdate.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, propertyToUpdate);
            Assert.IsNull(fromDbOld);
        }

        [Test]
        public void CannotConvertWhenThereIsNoValidUnits()
        {
            var nonConvertible = _propertyRepository.GetByName("Prop1");

            Assert.IsNotNull(nonConvertible);
            Assert.IsFalse(nonConvertible.IsConvertible());
        }

        [Test]
        public void CanConvertWhenThereAreValidUnits()
        {
            var nonConvertible = _propertyRepository.GetByName("Prop3");

            Assert.IsNotNull(nonConvertible);
            Assert.IsTrue(nonConvertible.IsConvertible());
        }
    }
}