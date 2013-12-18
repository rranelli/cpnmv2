using Castle.MicroKernel.Registration;
using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.Cpnm.Data;

namespace Chemtech.CPNM.BR
{
    public class BusinessDIContainer : DataDIContainer
    {
        public BusinessDIContainer()
        {
            Register(Component.For<IAddressFactory>().ImplementedBy<AddressObjFactory>().LifeStyle.Transient);
        }
    }
}
