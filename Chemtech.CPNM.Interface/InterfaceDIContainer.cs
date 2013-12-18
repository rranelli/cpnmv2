using System.Windows;
using Castle.MicroKernel.Registration;
using Chemtech.CPNM.BR;
using Chemtech.CPNM.Interface.Controllers;
using Chemtech.CPNM.Interface.ViewModels;
using Chemtech.CPNM.Interface.Views;

namespace Chemtech.CPNM.Interface
{
    public class InterfaceDIContainer : BusinessDIContainer
    {
        public InterfaceDIContainer()
        {
            Register(Component.For<Window>().ImplementedBy<SetupReuseView>().Named("SetupReuseView"));
            Register(Component.For<Window>().ImplementedBy<GetAddressView>().Named("GetAddressView"));
            
            Register(Component.For<IGetAddressViewModel>().ImplementedBy<GetAddressViewModel>().Named("GetAddressViewModel"));
            Register(Component.For<ISetupReuseViewModel>().ImplementedBy<SetupReuseViewModel>().Named("SetupReuseViewModel"));

            Register(Component.For<IAppController>().ImplementedBy<AppOfficeControllerBase>().Named("AppOfficeControllerBase"));
        }
    }
}
