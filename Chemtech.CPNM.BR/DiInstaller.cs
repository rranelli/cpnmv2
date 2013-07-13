using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chemtech.CPNM.BR.Rules;

namespace Chemtech.CPNM.BR
{
    public class DiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAddressHandler>().ImplementedBy<AddressHandler>());
        }
    }
}
