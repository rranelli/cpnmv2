using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.IApps;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Interface.ViewModels;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AppExcelImportExportControllerBase : AppControllerBase
    {
        public AppExcelImportExportControllerBase(ICPNMApp cpnmApp, IGetAddressViewModel addressViewModel, IAddressFactory addressFactory, ISetupReuseViewModel setupReuseViewModel)
            : base(cpnmApp, addressViewModel, addressFactory, setupReuseViewModel) {}
    }
}
