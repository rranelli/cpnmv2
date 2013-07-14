using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chemtech.CPNM.Tests.UnitTests;

namespace Chemtech.CPNM.Tests
{
    public class InstallerTests : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITestHelper>().ImplementedBy<TestHelper>());
        }
    }
}
