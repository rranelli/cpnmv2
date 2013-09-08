using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Interface.ViewModels;
using Chemtech.CPNM.Interface.Views;
using Chemtech.Cpnm.Data.Repositories;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AppExcelImportExportControllerBase : AppOfficeControllerBase
    {
        public AppExcelImportExportControllerBase(ICPNMApp cpnmApp, IGetAddressViewModel addressViewModel, IAddressFactory addressFactory, ISetupReuseView setupReuseView)
            : base(cpnmApp, addressViewModel, addressFactory, setupReuseView) {}
    }
}
