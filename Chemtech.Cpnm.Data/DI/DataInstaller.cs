using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.Cpnm.Data.Addresses;
using NHibernate;
using NHibernate.Cfg;

namespace Chemtech.Cpnm.Data
{
    public class DataInstaller : IWindsorInstaller
    {
        private readonly ISessionFactory _sessionFactory;

        public DataInstaller()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(DimensionRepository).Assembly);
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // repositories
            container.Register(Component.For<IDimensionRepository>().ImplementedBy<DimensionRepository>());
            container.Register(Component.For<IDisciplineRepository>().ImplementedBy<DisciplineRepository>());
            container.Register(Component.For<IItemRepository>().ImplementedBy<ItemRepository>());
            container.Register(Component.For<IItemTypeGroupRepository>().ImplementedBy<ItemTypeGroupRepository>());
            container.Register(Component.For<IItemTypeRepository>().ImplementedBy<ItemTypeRepository>());
            container.Register(Component.For<IPropertyGroupRepository>().ImplementedBy<PropertyGroupRepository>());
            container.Register(Component.For<IPropertyRepository>().ImplementedBy<PropertyRepository>());
            container.Register(Component.For<IPropValueRepository>().ImplementedBy<PropValueRepository>());
            container.Register(Component.For<ISubAreaRepository>().ImplementedBy<SubAreaRepository>());
            container.Register(Component.For<IUnitOfMeasureRepository>().ImplementedBy<UnitOfMeasureRepository>());
            container.Register(Component.For<IXrefRepository>().ImplementedBy<XrefRepository>());

            container.Register(Component.For(typeof(IGeneralRepository<>)).ImplementedBy(typeof(GeneralRepository<>)).LifeStyle.Transient);
            
            // Address handling
            container.Register(Component.For<IAddressFactory>().ImplementedBy<AddressObjFactory>());

            // other
            container.Register(Component.For<ISession>().UsingFactoryMethod(_sessionFactory.OpenSession));
        }
    }
}
