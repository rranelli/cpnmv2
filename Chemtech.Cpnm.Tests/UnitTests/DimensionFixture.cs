using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Data.Repositories;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    class DimensionFixture
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
        public void CanGetDimensionByName()
        {
            var repository = new DimensionRepository();

            var pressao = repository.GetByName("Vazao");

            Assert.IsNotNull(pressao);
            Assert.AreEqual(pressao.Name, "Vazao");
            Assert.IsNotNull(pressao.Units);
        }

        [Test]
        public void CanAddDimension()
        {
            var newUnits = new UnitOfMeasure[]
                              {
                                  new UnitOfMeasure()
                                      {
                                          ConvFactor = 1.2,
                                          OffsetFactor = 0,
                                          Symbol = "Symb"
                                      }
                              };

            var newDimension = new Dimension() { Name = "Entalpia", Units = newUnits };
            var repository = new DimensionRepository();

            repository.Add(newDimension);

            var fromDb = repository.GetById(newDimension.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(newDimension, fromDb);
            Assert.AreEqual(newDimension.Units.First(), newUnits[0]);
        }

        [Test]
        public void CanRemoveDimension()
        {
            var repository = new DimensionRepository();
            var unitrepository = new GeneralRepository<UnitOfMeasure>();
            var dumbUnit = new UnitOfMeasure {ConvFactor = 1.1, OffsetFactor = 1.2, Symbol = "1123"};
            var dumbdim = new Dimension {Name = "duuuuumb", Units = new[] {dumbUnit}};
            repository.Add(dumbdim);

            // asserting que a dimensao e a unidade foram criadas
            var fromDb = repository.GetById(dumbdim.Id);
            var unitFromDb = unitrepository.GetById(dumbUnit.Id);
            Assert.IsNotNull(fromDb);
            Assert.IsNotNull(unitFromDb);

            var dimensionToRemove = repository.GetByName("duuuuumb");
            repository.Remove(dimensionToRemove);

            // asserting que a dimensao e a unidade foram criadas
            fromDb = repository.GetById(dimensionToRemove.Id);
            unitFromDb = unitrepository.GetById(dumbUnit.Id);
            Assert.IsNotNull(dimensionToRemove);
            Assert.IsNull(fromDb);
            Assert.IsNull(unitFromDb);
        }

        [Test]
        public void CanUpdateDimension()
        {
            var repository = new DimensionRepository();
            var fluxo = repository.GetByName("Vazao");
            fluxo.Name = "Fluxo.... Oh god que nome errado.";
            var firstUnit = fluxo.Units.First();

            fluxo.Units.Remove(fluxo.Units.First());
            repository.Update(fluxo);

            var fromDb = repository.GetByName(fluxo.Name);
            var fromDbOld = repository.GetByName("Vazao");

            Assert.IsNotNull(fluxo);
            Assert.IsNotNull(fromDb);
            Assert.IsNull(fromDbOld);
            Assert.IsFalse(fromDb.Units.Contains(firstUnit));
            Assert.AreEqual(fluxo.Name, fromDb.Name);
        }
    }
}