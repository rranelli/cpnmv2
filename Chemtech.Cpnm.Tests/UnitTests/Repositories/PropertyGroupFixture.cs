// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using Chemtech.CPNM.BR;
using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests.Repositories
{
    internal class PropertyGroupFixture
    {
        private Configuration _configuration;
        private IPropertyGroupRepository _propertyGroupRepository;
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
            _propertyGroupRepository = DiResolver.IocResolve<IPropertyGroupRepository>();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _testHelper.TestTearDown(_configuration);
        }

        #endregion

        [Test]
        public void CanAddPropertyGroup()
        {
            var propertyGroup = new PropertyGroup {Name = "A New Groupz"};

            _propertyGroupRepository.Add(propertyGroup);
            var fromDb = _propertyGroupRepository.GetById(propertyGroup.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.Id, propertyGroup.Id);
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