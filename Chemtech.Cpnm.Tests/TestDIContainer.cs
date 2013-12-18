using Castle.MicroKernel.Registration;
using Chemtech.CPNM.Interface;
using Chemtech.CPNM.Tests.UnitTests;

namespace Chemtech.CPNM.Tests
{
    public class TestDIContainer : InterfaceDIContainer
    {
        public TestDIContainer()
        {
            Register(Component.For<ITestHelper>().ImplementedBy<TestHelper>());
        }
    }
}
