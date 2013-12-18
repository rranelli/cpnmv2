using System.Windows;
using Castle.MicroKernel;
using Chemtech.CPNM.Interface.Controllers;
using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Model.Domain;
using Microsoft.Office.Tools.Ribbon;

// TODO: fazer o resolve da injecao de dependencia direito.
// TODO: eliminar o controller private.

namespace Chemtech.CPNM.App.Excel
{
    public partial class CPNMRibbon
    {
        private void CPNMRibbon_Load(object sender, RibbonUIEventArgs e) {}

        private void btnInsertReference_Click(object sender, RibbonControlEventArgs e)
        {
            getController().InsertReferenceAction();
        }

        private void btnUpdateReferences_Click(object sender, RibbonControlEventArgs e)
        {
            getController().UpdateReferencesAction();
        }

        private void btnApplyItemReuse_Click(object sender, RibbonControlEventArgs e)
        {
            getController().ApplyReferenceReuseAction();
        }

        private IAppController getController()
        {
            // TODO: good lord..... IOC com mvvm ta ficando uma zona, pqp!


            var container = new AppExcelDIContainer();
            var appExcel = container.Resolve<ICPNMApp>("CPNMAppExcel",
                                                       new Arguments(new {appExcel = Globals.ThisAddIn.Application}));
            var setupReuseViewModel = container.Resolve<Window>("SetupReuseViewModel",
                                                                                   new Arguments(new {existantItems =  new Item[]{new Item(), }}));
            return container.Resolve<IAppController>("AppOfficeControllerBase",
                                                     new Arguments(new {cpnmApp = appExcel, setupReuseViewModel = setupReuseViewModel}));
        }
    }
}