using System;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Chemtech.CPNM.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("HelloWorld!!!!");
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(ItemTypeGroup).Assembly);
            cfg.AddAssembly(typeof(ItemTypeGroupRepository).Assembly);
            new SchemaExport(cfg).Drop(false, true);
        }
    }
}