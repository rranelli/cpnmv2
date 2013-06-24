﻿// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class DisciplineFixture
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
        public void CanGetDisciplineByName()
        {
            var repository = new DisciplineRepository();

            var processo = repository.GetByName("Processo");

            Assert.IsNotNull(processo);
            Assert.AreEqual(processo.Name, "Processo");
        }

        [Test]
        public void CanAddDiscipline()
        {
            var newDiscipline = new Discipline {Name = "Planejamento"};
            var repository = new DisciplineRepository();

            repository.Add(newDiscipline);

            var fromDb = repository.GetById(newDiscipline.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(newDiscipline, fromDb);
        }

        [Test]
        public void CanRemoveDiscipline()
        {
            var repository = new DisciplineRepository();
            var disciplineToRemove = repository.GetByName("Eletrica");
            repository.Remove(disciplineToRemove);

            var fromDb = repository.GetById(disciplineToRemove.Id);

            Assert.IsNotNull(disciplineToRemove);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateDiscipline()
        {
            var repository = new DisciplineRepository();
            var tubulacao = repository.GetByName("Tubulacao");
            tubulacao.Name = "Tubulação";
            repository.Update(tubulacao);

            var fromDb = repository.GetByName(tubulacao.Name);
            var fromDbOld = repository.GetByName("Tubulacao");

            Assert.IsNotNull(tubulacao);
            Assert.IsNotNull(fromDb);
            Assert.IsNull(fromDbOld);
            Assert.AreEqual(tubulacao.Name, fromDb.Name);
        }
    }
}