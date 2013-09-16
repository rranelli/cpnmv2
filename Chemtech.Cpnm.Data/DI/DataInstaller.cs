using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chemtech.CPNM.Data.Repositories;
using NHibernate;

namespace Chemtech.Cpnm.Data.DI
{
    public class DataInstaller : IWindsorInstaller
    {
        private readonly ISessionFactory _sessionFactory;

        public DataInstaller()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(DimensionRepository).Assembly);
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // repositories
            // Aqui estou configurando de tal forma que cada request vai gerar novas instancias dos repositorios e da session.
            // Dessa forma o usuario vai poder ver as alteracoes quando elas acontecerem. O problema eh que acho que isso nao
            // vai deixar o cara fazer um cache na sessao local. O esquema vai ser transformar o cpnm em um app web mesmo....

            container.Register(Component.For<IDimensionRepository>().ImplementedBy<DimensionRepository>().LifeStyle.Transient);
            container.Register(Component.For<IDisciplineRepository>().ImplementedBy<DisciplineRepository>().LifeStyle.Transient);
            container.Register(Component.For<IItemRepository>().ImplementedBy<ItemRepository>().LifeStyle.Transient);
            container.Register(Component.For<IItemTypeGroupRepository>().ImplementedBy<ItemTypeGroupRepository>().LifeStyle.Transient);
            container.Register(Component.For<IItemTypeRepository>().ImplementedBy<ItemTypeRepository>().LifeStyle.Transient);
            container.Register(Component.For<IPropertyGroupRepository>().ImplementedBy<PropertyGroupRepository>().LifeStyle.Transient);
            container.Register(Component.For<IPropertyRepository>().ImplementedBy<PropertyRepository>().LifeStyle.Transient);
            container.Register(Component.For<IPropValueRepository>().ImplementedBy<PropValueRepository>().LifeStyle.Transient);
            container.Register(Component.For<ISubAreaRepository>().ImplementedBy<SubAreaRepository>().LifeStyle.Transient);
            container.Register(Component.For<IUnitOfMeasureRepository>().ImplementedBy<UnitOfMeasureRepository>().LifeStyle.Transient);
            container.Register(Component.For<IXrefRepository>().ImplementedBy<XrefRepository>().LifeStyle.Transient);

            container.Register(Component.For(typeof(IGeneralRepository<>)).ImplementedBy(typeof(GeneralRepository<>)).LifeStyle.Transient);
            
            // other
            container.Register(Component.For<ISession>().UsingFactoryMethod(_sessionFactory.OpenSession).LifeStyle.Transient);
        }
    }
}
