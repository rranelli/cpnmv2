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

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(DimensionRepository).Assembly);
            _configuration.AddAssembly(typeof(UnitOfMeasure).Assembly);
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
            var dimensions = new Dimension[]
                                  {
                                      new Dimension() {Name = "Vazao", Units = unitsOfMeasure},
                                      new Dimension() {Name = "Pressao"},
                                      new Dimension() {Name = "Potencia"},
                                      new Dimension() {Name = "Tensao"},
                                      new Dimension() {Name = "Ovo"}
                                  };
            addGroups(dimensions);
        }

        private void addGroups(Dimension[] dimensions)
        {
            var repository = new DimensionRepository();
            foreach (var thisDim in dimensions)
            {
                repository.Add(thisDim);
            }
        }

        [Test]
        public void CanGetDimensionByName()
        {
            var repository = new DimensionRepository();

            var pressao = repository.GetByName("Pressao");

            Assert.IsNotNull(pressao);
            Assert.AreEqual(pressao.Name, "Pressao");
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
            var dimensionToRemove = repository.GetByName("Ovo");
            repository.Remove(dimensionToRemove);

            var fromDb = repository.GetById(dimensionToRemove.Id);

            Assert.IsNotNull(dimensionToRemove);
            Assert.IsNull(fromDb);
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