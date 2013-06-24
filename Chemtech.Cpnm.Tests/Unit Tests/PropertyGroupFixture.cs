﻿// PropertyGroupFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 06/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class PropertyGroupFixture
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
        public void CanAddPropertyGroup()
        {
            var propertyGroup = new PropertyGroup();
            string groupName = "A New Group";
            propertyGroup.Name = groupName;

            var repository = new PropertyGroupRepository();
            repository.Add(propertyGroup);
            PropertyGroup fromDb = repository.GetById(propertyGroup.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.Id, propertyGroup.Id);
            Assert.AreNotSame(fromDb, propertyGroup);
        }

        [Test]
        public void CanRemovePropertyGroup()
        {
            var repository = new PropertyGroupRepository();
            repository.Add(new PropertyGroup {Name = "grupo baguncado"});
            PropertyGroup propGroupToRemove = repository.GetByName("grupo baguncado");
            Assert.IsNotNull(propGroupToRemove);

            repository.Remove(propGroupToRemove);
            PropertyGroup fromDb = repository.GetById(propGroupToRemove.Id);
            Assert.IsNotNull(propGroupToRemove);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdatePropertyGroup()
        {
            var repository = new PropertyGroupRepository();
            PropertyGroup propGroupToUpdate = repository.GetByName("Dados de Fornecedor");
            propGroupToUpdate.Name = "Dados da WEG";
            repository.Update(propGroupToUpdate);

            PropertyGroup fromDbOld = repository.GetByName("Dados de Fornecedor");
            PropertyGroup fromDb = repository.GetById(propGroupToUpdate.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb, propGroupToUpdate);
            Assert.IsNull(fromDbOld);
        }
    }
}