// DimensionFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 10/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System.Linq;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class DimensionFixture
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

            Dimension pressao = repository.GetByName("Vazao");

            Assert.IsNotNull(pressao);
            Assert.AreEqual(pressao.Name, "Vazao");
            Assert.IsNotNull(pressao.Units);
        }

        [Test]
        public void CanAddDimension()
        {
            var newUnits = new[]
                               {
                                   new UnitOfMeasure
                                       {
                                           ConvFactor = 1.2,
                                           OffsetFactor = 0,
                                           Symbol = "Symb"
                                       }
                               };

            var newDimension = new Dimension {Name = "Entalpia", Units = newUnits};
            var repository = new DimensionRepository();

            repository.Add(newDimension);

            Dimension fromDb = repository.GetById(newDimension.Id);

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
            Dimension fromDb = repository.GetById(dumbdim.Id);
            UnitOfMeasure unitFromDb = unitrepository.GetById(dumbUnit.Id);
            Assert.IsNotNull(fromDb);
            Assert.IsNotNull(unitFromDb);

            Dimension dimensionToRemove = repository.GetByName("duuuuumb");
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
            Dimension fluxo = repository.GetByName("Vazao");
            fluxo.Name = "Fluxo.... Oh god que nome errado.";
            UnitOfMeasure firstUnit = fluxo.Units.First();

            fluxo.Units.Remove(fluxo.Units.First());
            repository.Update(fluxo);

            Dimension fromDb = repository.GetByName(fluxo.Name);
            Dimension fromDbOld = repository.GetByName("Vazao");

            Assert.IsNotNull(fluxo);
            Assert.IsNotNull(fromDb);
            Assert.IsNull(fromDbOld);
            Assert.IsFalse(fromDb.Units.Contains(firstUnit));
            Assert.AreEqual(fluxo.Name, fromDb.Name);
        }
    }
}