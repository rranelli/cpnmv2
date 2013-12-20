using Castle.MicroKernel.Registration;
using Chemtech.CPNM.BR;
using Chemtech.CPNM.Interface.Controllers;
using Chemtech.CPNM.Interface.ViewModels;

namespace Chemtech.CPNM.Interface
{
    public class InterfaceDIContainer : BusinessDIContainer
    {
        public InterfaceDIContainer()
        {
            Register(Component.For<IGetAddressViewModel>().ImplementedBy<GetAddressViewModel>());
            Register(Component.For<ISetupReuseViewModel>().ImplementedBy<SetupReuseViewModel>());

            Register(Component.For<IAppController>().ImplementedBy<AppControllerBase>().LifeStyle.Transient);
        }
    }
}
