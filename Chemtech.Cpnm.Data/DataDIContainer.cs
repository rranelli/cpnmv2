using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Proxy;
using Chemtech.CPNM.Data.Repositories;
using NHibernate;

namespace Chemtech.Cpnm.Data
{
    public class DataDIContainer : WindsorContainer
    {
        private readonly ISessionFactory _sessionFactory;

        public DataDIContainer()
        {
            // configuring NHibernate
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(DimensionRepository).Assembly);
            _sessionFactory = configuration.BuildSessionFactory();

            Kernel.ProxyFactory = new DefaultProxyFactory(true);

            Register(Component.For<IDimensionRepository>()    .ImplementedBy<DimensionRepository>()    .LifeStyle.Singleton);
            Register(Component.For<IDisciplineRepository>()   .ImplementedBy<DisciplineRepository>()   .LifeStyle.Singleton);
            Register(Component.For<IItemRepository>()         .ImplementedBy<ItemRepository>()         .LifeStyle.Singleton);
            Register(Component.For<IItemTypeGroupRepository>().ImplementedBy<ItemTypeGroupRepository>().LifeStyle.Singleton);
            Register(Component.For<IItemTypeRepository>()     .ImplementedBy<ItemTypeRepository>()     .LifeStyle.Singleton);
            Register(Component.For<IPropertyGroupRepository>().ImplementedBy<PropertyGroupRepository>().LifeStyle.Singleton);
            Register(Component.For<IPropertyRepository>()     .ImplementedBy<PropertyRepository>()     .LifeStyle.Singleton);
            Register(Component.For<IPropValueRepository>()    .ImplementedBy<PropValueRepository>()    .LifeStyle.Singleton);
            Register(Component.For<ISubAreaRepository>()      .ImplementedBy<SubAreaRepository>()      .LifeStyle.Singleton);
            Register(Component.For<IUnitOfMeasureRepository>().ImplementedBy<UnitOfMeasureRepository>().LifeStyle.Singleton);
            Register(Component.For<IXrefRepository>()         .ImplementedBy<XrefRepository>()         .LifeStyle.Singleton);

            Register(Component.For(typeof(IGeneralRepository<>)).ImplementedBy(typeof(GeneralRepository<>)).LifeStyle.Singleton);
            
            Register(Component.For<ISession>().UsingFactoryMethod(_sessionFactory.OpenSession).LifeStyle.Singleton);
        }
    }
}