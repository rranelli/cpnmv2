using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Chemtech.CPNM.Presentation
{
    public class DiResolver
    {
        private readonly IWindsorContainer _container;

        public  DiResolver()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.Install(FromAssembly.Named("Chemtech.CPNM.BR"));
            _container.Install(FromAssembly.Named("Chemtech.CPNM.Data"));
            _container.Install(FromAssembly.Named("Chemtech.CPNM.Model"));
            _container.Install(FromAssembly.Named("Chemtech.CPNM.Tests"));
        }

        public T IocResolve<T> ()
        {
            return _container.Resolve<T>();
        }

        public IWindsorContainer Getcontainer()
        {
            return _container;
        }
    }
}