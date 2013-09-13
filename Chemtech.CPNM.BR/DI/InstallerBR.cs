using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chemtech.CPNM.BR.AddressHandling;

namespace Chemtech.CPNM.BR.DI
{
    public class InstallerBR : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAddressFactory>().ImplementedBy<AddressObjFactory>());
        }
    }
}