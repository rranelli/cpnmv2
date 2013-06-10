using CPNMv2.Domain;
using CPNMv2.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CPNMv2.Tests.UnitTests
{
    class ItemTypeGroupFixtures
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(ItemTypeGroup).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [SetUp]
        public void TestSetUp()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            var itemTypeGroups = new ItemTypeGroup[]
                                     {
                                         new ItemTypeGroup() {Name = "Instrumentos", Description = "desc1"},
                                         new ItemTypeGroup() {Name = "Caldeiraria", Description = "123"},
                                         new ItemTypeGroup() {Name = "Estaticos", Description = "123"},
                                         new ItemTypeGroup() {Name = "Rotativos", Description = "123"},
                                         new ItemTypeGroup() {Name = "Documentos", Description = "123"},
                                         new ItemTypeGroup() {Name = "Eletrica", Description = "123"},
                                         new ItemTypeGroup() {Name = "Metalica", Description = "123"},
                                         new ItemTypeGroup() {Name = "Tubulacao", Description = "123"}
                                     };
            addGroups(itemTypeGroups);
        }

        private void addGroups(ItemTypeGroup[] itemTypeGroups)
        {
            var repository = new ItemTypeGroupRepository();
            foreach (var thisGroup in itemTypeGroups)
            {
                repository.Add(thisGroup);
            }
        }

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