using Castle.MicroKernel;
using Chemtech.CPNM.BR.Apps;
using Chemtech.CPNM.Interface.Controllers;
using Chemtech.CPNM.Interface.ViewModels;
using Chemtech.CPNM.Interface.Views;
using Microsoft.Office.Tools.Ribbon;

namespace Chemtech.CPNM.App.Excel
{
    public partial class CPNMRibbon
    {
        private void CPNMRibbonLoad(object sender, RibbonUIEventArgs e) {}

        private void BtnInsertReferenceClick(object sender, RibbonControlEventArgs e)
        {
            GetController().InsertReferenceAction();
        }

        private void BtnUpdateReferencesClick(object sender, RibbonControlEventArgs e)
        {
            GetController().UpdateReferencesAction();
        }

        private void BtnApplyItemReuseClick(object sender, RibbonControlEventArgs e)
        {
            GetController().ApplyReferenceReuseAction();
        }

        private static IAppController GetController()
        {
            var container = new AppExcelDIContainer();
            var appExcel = container.Resolve<ICPNMApp>(new Arguments(new {appExcel = Globals.ThisAddIn.Application}));

            var getAddressView = new GetAddressView();
            var insertReferenceViewModel = container.Resolve<IGetAddressViewModel>(
                new Arguments(new {view = getAddressView}));

            var setupReuseView = new SetupReuseView();
            var setupReuseViewModel = container.Resolve<ISetupReuseViewModel>(
                new Arguments(new { existantItems = appExcel.GetReferencedItems(), view = setupReuseView }));
            
            return container.Resolve<IAppController>(
                new Arguments(new
                                  {
                                      cpnmApp = appExcel, 
                                      setupReuseViewModel,
                                      addressViewModel = insertReferenceViewModel
                                  }));
        }
    }
}