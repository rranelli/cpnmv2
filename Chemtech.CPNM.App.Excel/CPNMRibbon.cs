using Chemtech.CPNM.App.Excel.Application;
using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.Interface.Controllers;
using Chemtech.CPNM.Interface.ViewModels;
using Microsoft.Office.Tools.Ribbon;

// TODO: fazer o resolve da injecao de dependencia direito.
// TODO: eliminar o controller private.

namespace Chemtech.CPNM.App.Excel
{
    public partial class CPNMRibbon
    {
        private AppOfficeControllerBase _officeController;

        private void CPNMRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnInsertReference_Click(object sender, RibbonControlEventArgs e)
        {
            var getReferenceViewModel = DiResolver.IocResolve<IGetAddressViewModel>();
            var addressFactory = DiResolver.IocResolve<IAddressFactory>();
            var appExcel = new CPNMAppExcel(DiResolver.IocResolve<IAddressFactory>());
            ISetupReuseViewModel setupReuseViewModel = null;

            _officeController = new AppOfficeControllerBase(appExcel, getReferenceViewModel, addressFactory, setupReuseViewModel);

            _officeController.InsertReferenceAction();
        }

        private void btnUpdateReferences_Click(object sender, RibbonControlEventArgs e)
        {
            var getReferenceViewModel = DiResolver.IocResolve<IGetAddressViewModel>();
            var addressFactory = DiResolver.IocResolve<IAddressFactory>();
            var appExcel = new CPNMAppExcel(DiResolver.IocResolve<IAddressFactory>());
            ISetupReuseViewModel setupReuseViewModel = null;

            _officeController = new AppOfficeControllerBase(appExcel, getReferenceViewModel, addressFactory, setupReuseViewModel);

            _officeController.UpdateReferencesAction();
        }

        private void btnApplyItemReuse_Click(object sender, RibbonControlEventArgs e)
        {
            var getReferenceViewModel = DiResolver.IocResolve<IGetAddressViewModel>();
            var addressFactory = DiResolver.IocResolve<IAddressFactory>();
            var appExcel = new CPNMAppExcel(DiResolver.IocResolve<IAddressFactory>());
            ISetupReuseViewModel setupReuseViewModel = null;

            _officeController = new AppOfficeControllerBase(appExcel, getReferenceViewModel, addressFactory, setupReuseViewModel);

            _officeController.ApplyReferenceReuseAction();
        }
    }
}