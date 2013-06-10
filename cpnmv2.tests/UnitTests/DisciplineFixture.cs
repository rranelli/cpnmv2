using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using CPNMv2.Repositories;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CPNMv2.Tests.UnitTests
{
    class DisciplineFixture
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
            var disciplines = new Discipline[]
                                  {
                                      new Discipline() {Name = "Eletrica"},
                                      new Discipline() {Name = "Processo"},
                                      new Discipline() {Name = "Tubulacao"},
                                      new Discipline() {Name = "Metalica"},
                                      new Discipline() {Name = "Civil"}
                                  };
            addGroups(disciplines);
        }

        private void addGroups(Discipline[] disciplines)
        {
            var repository = new DisciplineRepository();
            foreach (var thisDisc in disciplines)
            {
                repository.Add(thisDisc);
            }
        }

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
            var newDiscipline = new Discipline() { Name = "Planejamento" };
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