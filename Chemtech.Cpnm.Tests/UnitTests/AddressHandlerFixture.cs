// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

using System.Linq;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.BR.Rules;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    internal class AddressHandlerFixture
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
        public void CanParseAddress()
        {
            var thisItem = new ItemRepository().GetByName("Complex");
            var thisPropValue = thisItem.PropValues.ToList().Last();
            var thisProperty = thisPropValue.GetProperty;
            var thisUnit = thisProperty.Dimension.Units.First();

            var thisDto = new AddressHandler {PropValue = thisPropValue, UnitOfMeasure = thisUnit, FormatType= PropValue.FormatType.Value};
            var theAddress = thisDto.Address;

            var anotherDto = new AddressHandler(theAddress);

            Assert.AreEqual(thisDto.PropValue, anotherDto.PropValue);
            Assert.AreEqual(thisDto.FormatType, anotherDto.FormatType);
            Assert.AreEqual(thisDto.UnitOfMeasure, anotherDto.UnitOfMeasure);
        }
    }
}