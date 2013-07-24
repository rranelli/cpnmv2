using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chemtech.CPNM.Presentation.Controllers;

namespace Chemtech.CPNM.Presentation.DI
{
    public class UIInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IAppController>().ImplementedBy<AppOfficeController>().Named("AppOfficeController"));
        }
    }
}
