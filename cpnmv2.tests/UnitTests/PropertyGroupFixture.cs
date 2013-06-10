using CPNMv2.Domain;
using CPNMv2.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CPNMv2.Tests.UnitTests
{
    class PropertyGroupFixture
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(PropertyGroup).Assembly);
        }

        [SetUp]
        public void TestSetUp()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            var propGroups = new PropertyGroup[]
                                     {
                                         new PropertyGroup() {Name = "Dados de Processo", Description = "desc1"},
                                         new PropertyGroup() {Name = "Dados de Fornecedor", Description = "123"},
                                         new PropertyGroup() {Name = "Dados de Catalogo", Description = "123"},
                                         new PropertyGroup() {Name = "Dados Tecnicos", Description = "123"},
                                         new PropertyGroup() {Name = "Tagueamento e rastreabilidade", Description = "123"},
                                         new PropertyGroup() {Name = "Materiais", Description = "123"},
                                         new PropertyGroup() {Name = "Dados EAP", Description = "123"},
                                     };
            addGroups(propGroups);
        }

        private void addGroups(PropertyGroup[] groups)
        {
            var repository = new PropertyGroupRepository();
            foreach (var thisGroup in groups)
            {
                repository.Add(thisGroup);
            }
        }

        [Test]
        public void CanAddPropertyGroup()
        {
            var propertyGroup = new PropertyGroup();
            var groupName = "A New Group";
            propertyGroup.Name = groupName;

            var repository = new PropertyGroupRepository();
            repository.Add(propertyGroup);
            var fromDb = repository.GetById(propertyGroup.Id);
         
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.Id, propertyGroup.Id);
            Assert.AreNotSame(fromDb, propertyGroup);
        }

        [Test]
        public void CanRemovePropertyGroup()
        {
            var repository = new PropertyGroupRepository();
            var propGroupToRemove = repository.GetByName("Dados de Processo");
            repository.Remove(propGroupToRemove);
            var fromDb = repository.GetById(propGroupToRemove.Id);

            Assert.IsNotNull(propGroupToRemove);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdatePropertyGroup()
        {
            var repository = new PropertyGroupRepository();
            var propGroupToUpdate = repository.GetByName("Dados de Fornecedor");
            propGroupToUpdate.Name = "Dados da WEG";
            repository.Update(propGroupToUpdate);

            var fromDbOld = repository.GetByName("Dados de Fornecedor");
            var fromDb = repository.GetById(propGroupToUpdate.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, propGroupToUpdate);
            Assert.IsNull(fromDbOld);
        }
    }
}