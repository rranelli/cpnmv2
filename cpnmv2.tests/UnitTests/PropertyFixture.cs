using System.Collections.Generic;
using CPNMv2.Domain;
using CPNMv2.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CPNMv2.Tests.UnitTests
{
    class PropertyFixture
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Property).Assembly);
        }

        [SetUp]
        public void TestSetUp()
        {
            new SchemaExport(_configuration).Execute(false, true, false);

            var unitsOfMeasure = new UnitOfMeasure[] 
                                            {
                                                new UnitOfMeasure() {ConvFactor = 1, OffsetFactor = 0,Symbol = "K"},
                                                new UnitOfMeasure() {ConvFactor = 2, OffsetFactor = 0,Symbol = "C"},
                                                new UnitOfMeasure() {ConvFactor = 3, OffsetFactor = 1, Symbol = "T"}
                                            };

            var dimension = new Dimension() { Units = unitsOfMeasure, Name = "dummyDim" };
            var dimensionRepository = new DimensionRepository();
            dimensionRepository.Add(dimension);

            var properties = new Property[]
                                     {
                                         new Property() {Name = "Prop1", Description = "desc1"},
                                         new Property() {Name = "Prop2", },
                                         new Property() {Name = "Prop3", Dimension = dimension, DefaultUnit = unitsOfMeasure[0]}
                                     };
            addGroups(properties);
        }

        private void addGroups(IEnumerable<Property> properties)
        {
            var repository = new PropertyRepository();
            foreach (var thisproperty in properties)
            {
                repository.Add(thisproperty);
            }
        }

        [Test]
        public void CanAddProperty()
        {
            var property = new Property();
            var propertyname = "Prop115";
            property.Name = propertyname;

            var repository = new PropertyRepository();
            repository.Add(property);
            var fromDb = repository.GetById(property.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.Id, property.Id);
            Assert.AreNotSame(fromDb, property);
        }

        [Test]
        public void CanRemovePropertyGroup()
        {
            var repository = new PropertyRepository();
            var propertyToRemove = repository.GetByName("Prop2");
            repository.Remove(propertyToRemove);
            var fromDb = repository.GetById(propertyToRemove.Id);

            Assert.IsNotNull(propertyToRemove);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdatePropertyGroup()
        {
            var repository = new PropertyRepository();
            var propertyToUpdate = repository.GetByName("Prop1");
            propertyToUpdate.Name = "Prop1-love";
            repository.Update(propertyToUpdate);

            var fromDbOld = repository.GetByName("Prop1");
            var fromDb = repository.GetById(propertyToUpdate.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, propertyToUpdate);
            Assert.IsNull(fromDbOld);
        }

        [Test]
        public void CannotConvertWhenThereIsNoValidUnits()
        {
            var repository = new PropertyRepository();
            var nonConvertible = repository.GetByName("Prop1");

            Assert.IsNotNull(nonConvertible);
            Assert.IsFalse(nonConvertible.IsConvertible());
        }

        [Test]
        public void CanConvertWhenThereAreValidUnits()
        {
            var repository = new PropertyRepository();
            var nonConvertible = repository.GetByName("Prop3");

            Assert.IsNotNull(nonConvertible);
            Assert.IsTrue(nonConvertible.IsConvertible());
        }
    }
}