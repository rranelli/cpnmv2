using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Chemtech.CPNM.BR.Rules;
using Chemtech.CPNM.Data.Repositories;
using NHibernate;

namespace Chemtech.CPNM.BR
{
    public class CpnmStart
    {
        private readonly WindsorContainer _container;

        public CpnmStart()
        {
            _container = new WindsorContainer();
            IoCinstall();
        }

        public void IoCinstall()
        {
            //other
            _container.Register(Component.For<ISession>().UsingFactoryMethod(NHibernateHelper.OpenSession));
            
            // repositories
            _container.Register(Component.For<IDimensionRepository>().ImplementedBy<DimensionRepository>());
            _container.Register(Component.For<IItemRepository>().ImplementedBy<ItemRepository>());
            _container.Register(Component.For<IItemTypeGroupRepository>().ImplementedBy<ItemTypeGroupRepository>());
            _container.Register(Component.For<IItemTypeRepository>().ImplementedBy<ItemTypeRepository>());
            _container.Register(Component.For<IPropertyRepository>().ImplementedBy<PropertyRepository>());
            _container.Register(Component.For<IPropertyGroupRepository>().ImplementedBy<PropertyGroupRepository>());
            _container.Register(Component.For<IPropValueRepository>().ImplementedBy<PropValueRepository>());
            _container.Register(Component.For<ISubAreaRepository>().ImplementedBy<SubAreaRepository>());
            _container.Register(Component.For<IXrefRepository>().ImplementedBy<XrefRepository>());
            _container.Register(Component.For<IAddressHandler>().ImplementedBy<AddressHandler>());
        }

        public T IocResolve<T> ()
        {
            return _container.Resolve<T>();
        }
    }
}