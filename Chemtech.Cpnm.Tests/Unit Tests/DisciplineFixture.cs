// DisciplineFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 10/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using Chemtech.CPNM.BR;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class DisciplineFixture
    {
        private Configuration _configuration;
        private IDisciplineRepository _repository;

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
            _repository = new CpnmStart().IocResolve<IDisciplineRepository>();
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
            var processo = _repository.GetByName("Processo");
            Assert.IsNotNull(processo);
            Assert.AreEqual(processo.Name, "Processo");
        }

        [Test]
        public void CanAddDiscipline()
        {
            var newDiscipline = new Discipline {Name = "Planejamento"};

            _repository.Add(newDiscipline);

            var fromDb = _repository.GetById(newDiscipline.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(newDiscipline, fromDb);
        }

        [Test]
        public void CanRemoveDiscipline()
        {
            var disciplineToRemove = _repository.GetByName("Eletrica");
            _repository.Remove(disciplineToRemove);

            var fromDb = _repository.GetById(disciplineToRemove.Id);

            Assert.IsNotNull(disciplineToRemove);
            Assert.IsNull(fromDb);
        }

        [Test]
        public void CanUpdateDiscipline()
        {
            var tubulacao = _repository.GetByName("Tubulacao");
            tubulacao.Name = "Tubulação";
            _repository.Update(tubulacao);

            var fromDb = _repository.GetByName(tubulacao.Name);
            var fromDbOld = _repository.GetByName("Tubulacao");

            Assert.IsNotNull(tubulacao);
            Assert.IsNotNull(fromDb);
            Assert.IsNull(fromDbOld);
            Assert.AreEqual(tubulacao.Name, fromDb.Name);
        }
    }
}