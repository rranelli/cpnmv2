using CPNMv2.Domain;
using CPNMv2.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CPNMv2.Tests.UnitTests
{
    class PropertyGroupFixture
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(ItemTypeGroup).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [SetUp]
        public void TestSetUp()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
        }

        [Test]
        public void CanAddPropertyGroup()
        {
            var propertyGroup = new PropertyGroup();
            var groupName = "A New Group";
            propertyGroup.Name = groupName;

            var repository = new PropertyGroupRepository();
            repository.Add(propertyGroup);
            var fromDb = repository.GetById(propertyGroup.Id);
         
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.Id, propertyGroup.Id);
            Assert.AreNotSame(fromDb, propertyGroup);
        }
    }
}
