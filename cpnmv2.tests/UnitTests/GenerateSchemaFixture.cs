using CPNMv2.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace CPNMv2.Tests.UnitTests
{
    [TestFixture]
    public class GenerateSchemaFixture
    {
        [Test]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(ItemTypeGroup).Assembly);
            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}