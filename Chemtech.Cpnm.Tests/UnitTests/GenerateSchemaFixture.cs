using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests
{
    [TestFixture]
    public class GenerateSchemaFixture
    {
        [Test]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(DimensionRepository).Assembly);
            cfg.AddAssembly(typeof(UnitOfMeasure).Assembly);
            new SchemaExport(cfg).Drop(false, true);
            new SchemaExport(cfg).Create(false,true);
        }
    }
}