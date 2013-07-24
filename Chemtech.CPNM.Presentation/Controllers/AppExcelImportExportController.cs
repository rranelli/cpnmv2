using Chemtech.CPNM.App.Excel.Data.Repositories;
using Chemtech.CPNM.Presentation.IViewsModels;

namespace Chemtech.CPNM.Presentation.Controllers
{
    public class AppExcelImportExportController : AppOfficeController
    {
        public AppExcelImportExportController(ICPNMApp cpnmApp, IGetAddressView addressView, IAddressFactory addressFactory, ISetupReuseView setupReuseView)
            : base(cpnmApp, addressView, addressFactory, setupReuseView) {}
    }
}
