using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Chemtech.CPNM.BR.DI
{
    public static class DiResolver
    {
        private static readonly IWindsorContainer Container;

        static DiResolver()
        {
            Container = new WindsorContainer();
            Container.Install(FromAssembly.This());
            Container.Install(FromAssembly.Named("Chemtech.CPNM.BR"));
            Container.Install(FromAssembly.Named("Chemtech.CPNM.Data"));
            Container.Install(FromAssembly.Named("Chemtech.CPNM.Model"));
            Container.Install(FromAssembly.Named("Chemtech.CPNM.Tests"));
        }

        public static T IocResolve<T> ()
        {
            return Container.Resolve<T>();
        }

        public static IWindsorContainer Getcontainer()
        {
            return Container;
        }
    }
}