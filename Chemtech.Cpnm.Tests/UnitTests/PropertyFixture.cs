﻿// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class PropertyFixture
    {
        private Configuration _configuration;

        #region Fixture, Setup and Teardown config

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new TestHelper().MakeConfiguration();
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
        public void CanRemoveProperty()
        {
            var repository = new PropertyRepository();
            repository.Add(new Property {Name = "Ima gonna be remuvd"});
            var propertyToRemove = repository.GetByName("Ima gonna be remuvd");
            Assert.IsNotNull(propertyToRemove);

            repository.Remove(propertyToRemove);
            var fromDb = repository.GetById(propertyToRemove.Id);

            Assert.IsNotNull(propertyToRemove);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateProperty()
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