using System;
using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.IApps;
using Chemtech.CPNM.Interface.ViewModels;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AppAutoCadController : AppControllerBase
    {
        public AppAutoCadController(ICPNMApp cpnmApp, IGetAddressViewModel addressViewModel, IAddressFactory addressFactory, ISetupReuseViewModel setupReuseViewModel) : base(cpnmApp, addressViewModel, addressFactory, setupReuseViewModel) {}
    }
}
