﻿// GenerateSchemaFixture.cs
// Projeto: Chemtech.CPNM.Tests
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 06/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests.Repositories
{
    [TestFixture]
    public class GenerateSchemaFixture
    {
        [Test]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof (DimensionRepository).Assembly);
            cfg.AddAssembly(typeof (UnitOfMeasure).Assembly);
            new SchemaExport(cfg).Drop(false, true);
            new SchemaExport(cfg).Create(false, true);
        }
    }
}
