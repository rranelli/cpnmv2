using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chemtech.CPNM.Interface.ViewModels;
using Chemtech.CPNM.Interface.Views;

namespace Chemtech.CPNM.Interface.DI
{
    public class UIInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //TODO: we better implement some kind of selector. Maybe in the future we will choose to add more implementations of the views.
            //container.Register(Component.For<Window>().ImplementedBy<SetupReuseView>());
            container.Register(Component.For<Window>().ImplementedBy<GetAddressView>());
            container.Register(Component.For<IGetAddressViewModel>().ImplementedBy<GetAddressViewModel>());
            container.Register(Component.For<ISetupReuseViewModel>().ImplementedBy<SetupReuseViewModel>());
        }
    }
}
