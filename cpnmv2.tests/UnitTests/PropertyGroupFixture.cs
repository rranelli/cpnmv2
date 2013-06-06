using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using CPNMv2.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CPNMv2.Tests
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
            propertyGroup.GroupName = groupName;

            var repository = new PropertyGroupRepository();
            repository.Add(propertyGroup);
            var fromDb = repository.GetByID(propertyGroup.GroupKey);
         
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(fromDb.GroupKey, propertyGroup.GroupKey);
            Assert.AreNotSame(fromDb, propertyGroup);
        }
    }
}
