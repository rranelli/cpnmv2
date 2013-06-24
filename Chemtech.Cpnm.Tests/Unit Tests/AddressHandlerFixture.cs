// AddressHandlerFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 17/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System.Linq;
using Chemtech.CPNM.BR.Rules;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NUnit.Framework;
using Rhino.Mocks.Constraints;
using Property = Chemtech.CPNM.Model.Domain.Property;

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
            Item thisItem = new ItemRepository().GetByName("Complex");
            PropValue thisPropValue = thisItem.PropValues.ToList().Last();
            Property thisProperty = thisPropValue.GetProperty;
            UnitOfMeasure thisUnit = thisProperty.Dimension.Units.First();

            var thisDto = new AddressHandler
                              {
                                  PropValue = thisPropValue,
                                  UnitOfMeasure = thisUnit,
                                  FormatType = PropValue.FormatType.Value
                              };

            string theAddress = thisDto.Address;

            var anotherDto = new AddressHandler(theAddress);

            Assert.AreEqual(thisDto.PropValue, anotherDto.PropValue);
            Assert.AreEqual(thisDto.FormatType, anotherDto.FormatType);
            Assert.AreEqual(thisDto.UnitOfMeasure, anotherDto.UnitOfMeasure);
        }
    }
}