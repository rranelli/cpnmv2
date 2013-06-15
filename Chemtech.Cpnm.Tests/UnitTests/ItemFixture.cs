using System.Collections.Generic;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    class ItemFixture
    {
        private Configuration _configuration;

        [SetUp]
        public void SetUp()
        {
            new SchemaExport(_configuration).Execute(false, true, false);

            var unitsOfMeasure = new[] 
                                     {
                                         new UnitOfMeasure() {ConvFactor = 1, OffsetFactor = 0,Symbol = "K"},
                                         new UnitOfMeasure() {ConvFactor = 2, OffsetFactor = 0,Symbol = "C"},
                                         new UnitOfMeasure() {ConvFactor = 3, OffsetFactor = 1, Symbol = "T"}
                                     };

            var dimension = new Dimension() { Units = unitsOfMeasure, Name = "dummyDim" };

            var prop1 = new Property() { Name = "Prop1", Description = "desc1" };
            var prop2 = new Property() { Name = "Prop2" };
            var prop3 = new Property()
                            {
                                Name = "Prop3",
                                Dimension = dimension,
                                DefaultUnit = unitsOfMeasure[0]
                            };

            var propRepo = new PropertyRepository();
            propRepo.Add(prop1);
            propRepo.Add(prop2);
            propRepo.Add(prop3);

            var newItemType = new ItemType()
                                  {
                                      Name = "NovoTipo",
                                      ValidXrefs = new[]
                                                       {
                                                           new Xref() {Property = prop1}, 
                                                           new Xref() {Property = prop2},
                                                           new Xref() {Property = prop3}
                                                       }
                                  };

            var itemtyperepo = new ItemTypeRepository();
            itemtyperepo.Add(newItemType);

            var items = new[]
                            {
                                new Item {Name = "P-101", UniqueName = "P-101"},
                                new Item {Name = "Complex", UniqueName="Complex", IsActive = true, ItemType = newItemType}
                            };

            addItems(items);
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(DimensionRepository).Assembly);
            _configuration.AddAssembly(typeof(UnitOfMeasure).Assembly);
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
            var simpleItem = new Item { Name = "1112", UniqueName = "11123_1" };
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
            var repository = new ItemRepository();
            var proprepository = new PropertyRepository();
            var propvalrepo = new PropValueRepository();

            var complexItem = repository.GetByName("Complex");
            Assert.IsNotNull(complexItem);

            var property = proprepository.GetByName("Prop1");
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
