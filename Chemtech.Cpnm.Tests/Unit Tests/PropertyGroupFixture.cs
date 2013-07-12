// PropertyGroupFixture.cs
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
    internal class PropertyGroupFixture
    {
        private Configuration _configuration;
        private IPropertyGroupRepository _propertyGroupRepository;

        #region Fixture, Setup and Teardown config

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new TestHelper().MakeConfiguration();
            _propertyGroupRepository = new CpnmStart().IocResolve<IPropertyGroupRepository>();
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
        public void CanAddPropertyGroup()
        {
            var propertyGroup = new PropertyGroup();
            var groupName = "A New Group";
            propertyGroup.Name = groupName;

            _propertyGroupRepository.Add(propertyGroup);
            PropertyGroup fromDb = _propertyGroupRepository.GetById(propertyGroup.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.Id, propertyGroup.Id);
            Assert.AreNotSame(fromDb, propertyGroup);
        }

        [Test]
        public void CanRemovePropertyGroup()
        {
            _propertyGroupRepository.Add(new PropertyGroup {Name = "grupo baguncado"});
            var propGroupToRemove = _propertyGroupRepository.GetByName("grupo baguncado");
            Assert.IsNotNull(propGroupToRemove);

            _propertyGroupRepository.Remove(propGroupToRemove);
            var fromDb = _propertyGroupRepository.GetById(propGroupToRemove.Id);
            Assert.IsNotNull(propGroupToRemove);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdatePropertyGroup()
        {
            var propGroupToUpdate = _propertyGroupRepository.GetByName("Dados de Fornecedor");
            propGroupToUpdate.Name = "Dados da WEG";
            _propertyGroupRepository.Update(propGroupToUpdate);

            var fromDbOld = _propertyGroupRepository.GetByName("Dados de Fornecedor");
            var fromDb = _propertyGroupRepository.GetById(propGroupToUpdate.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, propGroupToUpdate);
            Assert.IsNull(fromDbOld);
        }
    }
}