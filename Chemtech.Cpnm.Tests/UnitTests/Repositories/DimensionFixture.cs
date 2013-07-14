// DimensionFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 10/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System.Linq;
using Chemtech.CPNM.BR;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Presentation;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class DimensionFixture
    {
        private Configuration _configuration;
        private IDimensionRepository _dimensionRepository;
        private IUnitOfMeasureRepository _unitOfMeasureRepository;
        private ITestHelper _testHelper;

        #region Fixture, Setup and Teardown config

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _testHelper = DiResolver.IocResolve<ITestHelper>();
            _configuration = _testHelper.MakeConfiguration();
        }

        [SetUp]
        public void SetUp()
        {
            _testHelper.SetUpDatabaseTestData(_configuration);
            _dimensionRepository = DiResolver.IocResolve<IDimensionRepository>();
            _unitOfMeasureRepository = DiResolver.IocResolve<IUnitOfMeasureRepository>();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _testHelper.TestTearDown(_configuration);
        }

        #endregion

        [Test]
        public void CanGetDimensionByName()
        {
            var pressao = _dimensionRepository.GetByName("Vazao");

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

            var newDimension = new Dimension { Name = "Entalpia", Units = newUnits };

            _dimensionRepository.Add(newDimension);

            Dimension fromDb = _dimensionRepository.GetById(newDimension.Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(newDimension, fromDb);
            Assert.AreEqual(newDimension.Units.First(), newUnits[0]);
        }

        [Test]
        public void CanRemoveDimension()
        {
            var dumbUnit = new UnitOfMeasure { ConvFactor = 1.1, OffsetFactor = 1.2, Symbol = "1123" };
            var dumbdim = new Dimension { Name = "duuuuumb", Units = new[] { dumbUnit } };
            _dimensionRepository.Add(dumbdim);

            // asserting que a dimensao e a unidade foram criadas
            var fromDb = _dimensionRepository.GetById(dumbdim.Id);
            var unitFromDb = _unitOfMeasureRepository.GetById(dumbUnit.Id);
            Assert.IsNotNull(fromDb);
            Assert.IsNotNull(unitFromDb);

            var dimensionToRemove = _dimensionRepository.GetByName("duuuuumb");
            _dimensionRepository.Remove(dimensionToRemove);

            // asserting que a dimensao e a unidade foram criadas
            fromDb = _dimensionRepository.GetById(dimensionToRemove.Id);
            unitFromDb = _unitOfMeasureRepository.GetById(dumbUnit.Id);
            Assert.IsNotNull(dimensionToRemove);
            Assert.IsNull(fromDb);
            Assert.IsNull(unitFromDb);
        }

        [Test]
        public void CanUpdateDimension()
        {
            var fluxo = _dimensionRepository.GetByName("Vazao");
            Assert.IsNotNull(fluxo);

            fluxo.Name = "Fluxo.... Oh god que nome errado.";

            //var firstUnit = fluxo.Units.First();
            //fluxo.Units.Remove(fluxo.Units.First());
            
            _dimensionRepository.Update(fluxo);

            var fromDb = _dimensionRepository.GetByName(fluxo.Name);
            var fromDbOld = _dimensionRepository.GetByName("Vazao");
            
            Assert.IsNotNull(fromDb);
            Assert.IsNull(fromDbOld);
            //Assert.IsFalse(fromDb.Units.Contains(firstUnit));
            Assert.AreEqual(fluxo.Name, fromDb.Name);
        }
    }
}