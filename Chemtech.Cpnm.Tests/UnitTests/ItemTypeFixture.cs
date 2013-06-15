using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Data.Repositories;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    class ItemTypeFixture
    {
        private Configuration _configuration;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(DimensionRepository).Assembly);
            _configuration.AddAssembly(typeof(UnitOfMeasure).Assembly);
        }

        [SetUp]
        public void TestSetUp()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            var itemTypeGroup = new ItemTypeGroup() { Name = "Estaticos" };
            var itemTypes = new ItemType[]
                                     {
                                         new ItemType() {Name = "Tanque", Description = "desc1", ItemTypeGroup = itemTypeGroup},
                                         new ItemType() {Name = "Transmissor", Description = "123", ItemTypeGroup = itemTypeGroup},
                                         new ItemType() {Name = "Bomba", Description = "123", ItemTypeGroup = itemTypeGroup},
                                         new ItemType() {Name = "Linha", Description = "123", ItemTypeGroup = itemTypeGroup},
                                         new ItemType() {Name = "Cantoneira", Description = "123", ItemTypeGroup = itemTypeGroup}
                                     };
            addGroups(itemTypes);
        }

        private void addGroups(ItemType[] itemTypes)
        {
            var repository = new ItemTypeRepository();
            foreach (var thisType in itemTypes)
            {
                repository.Add(thisType);
            }
        }

        [Test]
        public void CanAddItemType()
        {
            var itemType = new ItemType();
            var repository = new ItemTypeRepository();
            itemType.Name = "Tanque";

            repository.Add(itemType);
            var fromDb = repository.GetById(itemType.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, itemType);
            Assert.AreEqual(fromDb.Name, itemType.Name);
        }

        [Test]
        public void CanRemoveItemType()
        {
            var repository = new ItemTypeRepository();
            var typeToBeRemoved = repository.GetByName("Transmissor");
            repository.Remove(typeToBeRemoved);
            Assert.IsNotNull(typeToBeRemoved);

            var fromDb = repository.GetById(typeToBeRemoved.Id);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateItemType()
        {
            var repository = new ItemTypeRepository();
            var typeToBeUpdated = repository.GetByName("Bomba");
            typeToBeUpdated.Name = "Bombalove";
            repository.Update(typeToBeUpdated);

            var fromDb = repository.GetById(typeToBeUpdated.Id);
            var fromDbOld = repository.GetByName("Bomba");

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, typeToBeUpdated);
            Assert.IsNull(fromDbOld);
        }

        [Test]
        public void CanUpdateGroup()
        {
            var repository = new ItemTypeRepository();
            var typeToUpdateGroup = repository.GetByName("Bomba");
            var newItemTypeGroup = new ItemTypeGroup() { Name = "Rotativos" };

            typeToUpdateGroup.ItemTypeGroup = newItemTypeGroup;
            repository.Update(typeToUpdateGroup);

            var fromDb = repository.GetById(typeToUpdateGroup.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.ItemTypeGroup, typeToUpdateGroup.ItemTypeGroup);
        }

        [Test]
        public void CanUpdateValidProperties()
        {
            var prop2 = new Property() { Name = "Prop2" };
            var prop3 = new Property() {Name = "Prop3"};

            var propRepo = new PropertyRepository();
            propRepo.Add(prop2);
            propRepo.Add(prop3);

            var newItemType = new ItemType()
                                  {
                                      Name = "NovoTipo",
                                      ValidXrefs = new Xref[]
                                                            {   
                                                                new Xref() {Property = prop2},
                                                                new Xref() {Property = prop3}
                                                            }
                                  };

            var repository = new ItemTypeRepository();
            repository.Add(newItemType);
        }
    }
}