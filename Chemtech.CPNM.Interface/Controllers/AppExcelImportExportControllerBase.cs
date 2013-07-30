using Chemtech.CPNM.App.Excel.Data.Repositories;
using Chemtech.CPNM.Interface.IViewsModels;
using Chemtech.CPNM.Interface.ViewModels;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AppExcelImportExportControllerBase : AppOfficeControllerBase
    {
        public AppExcelImportExportControllerBase(ICPNMApp cpnmApp, IGetAddressViewModel addressViewModel, IAddressFactory addressFactory, ISetupReuseView setupReuseView)
            : base(cpnmApp, addressViewModel, addressFactory, setupReuseView) {}
    }
}
