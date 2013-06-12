using System.Collections.Generic;
using CPNMv2.Domain;
using CPNMv2.Repositories;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CPNMv2.Tests.UnitTests
{
    class ItemFixture
    {
        private Configuration _configuration;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(ItemTypeGroup).Assembly);
        }

        [SetUp]
        public void SetUp()
        {
            new SchemaExport(_configuration).Execute(false, true, false);

            var unitsOfMeasure = new UnitOfMeasure[] 
                                            {
                                                new UnitOfMeasure() {ConvFactor = 1, OffsetFactor = 0,Symbol = "K"},
                                                new UnitOfMeasure() {ConvFactor = 2, OffsetFactor = 0,Symbol = "C"},
                                                new UnitOfMeasure() {ConvFactor = 3, OffsetFactor = 1, Symbol = "T"}
                                            };

            var dimension = new Dimension() { Units = unitsOfMeasure, Name = "dummyDim" };
            var prop1 = new Property() {Name = "Prop1", Description = "desc1"};
            var propRepo = new PropertyRepository();
            propRepo.Add(prop1);

            var newItemType = new ItemType()
                                  {
                                      Name = "NovoTipo",
                                      ValidProperties = new Property[]
                                                            {
                                                                prop1,
                                                                new Property() {Name = "Prop2",},
                                                                new Property()
                                                                    {
                                                                        Name = "Prop3",
                                                                        Dimension = dimension,
                                                                        DefaultUnit = unitsOfMeasure[0]
                                                                    }
                                                            }
                                  };

            var items = new Item[]
                                  {
                                      new Item {Name = "P-101", UniqueName = "P-101"},
                                      new Item() {Name = "Complex", UniqueName="Complex", IsActive = true, ItemType = newItemType}
                                  };
            addItems(items);
        }

        private void addItems(IEnumerable<Item> itemTypes)
        {
            var repository = new ItemRepository();
            foreach (var thisItem in itemTypes)
            {
                repository.Add(thisItem);
            }
        }

        private Item GetFullItem()
        {
            return null;
        }

        [Test]
        public void CanAddItem()
        {
            var simpleItem = new Item() { Name = "1112", UniqueName = "11123_1" };
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
        public void CanUpdateItem()
        {
            var repository = new ItemRepository();
            var complexItem = repository.GetByName("Complex");
            Assert.IsNotNull(complexItem);

            complexItem.GetValue("Prop1").Value = "112.3";
            repository.Update(complexItem);

            var fromDb = repository.GetById(complexItem.Id);
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.GetValue("Prop1"), complexItem.GetValue("Prop1"));
        }
    }
}
