using System.Windows.Forms;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Presentation;
using Chemtech.Cpnm.AppExcel.ExportImport.Forms;
using Chemtech.Cpnm.AppExcel.ExportImport.Logic;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace Chemtech.Cpnm.AppExcel.ExportImport
{
    public partial class Ribbon
    {
        private SetUpExportWorkbook _setUpForm;
        private ExportDefinition _exportDefinition;
        private IExportSheetHandler _exportSheetHandler;

        private IItemRepository _itemRepository;

        private void Ribbon1Load(object sender, RibbonUIEventArgs e)
        {
            // Dependency inject resolve point.
            _itemRepository = DiResolver.IocResolve<IItemRepository>();
            _exportDefinition = DiResolver.IocResolve<IExportDefinition>();
            _exportSheetHandler = DiResolver.IocResolve<IExportSheetHandler>();
        }

        private void BtnConfigClick(object sender, RibbonControlEventArgs e)
        {
            _setUpForm.ShowDialog();
            if (_setUpForm.DialogResult != DialogResult.OK) return;
            _exportDefinition = new ExportDefinition(_itemRepository)
                                   {
                                       Properties = _setUpForm.SelectedProperties,
                                       SubArea = _setUpForm.SelectedSubArea,
                                       FetchAllItems = _setUpForm.FetchAllItems,
                                       ItemTypes = _setUpForm.SelectedItemTypes
                                   };
            _exportSheetHandler.FormatExport((Worksheet)Globals.ThisWorkbook.ActiveSheet, _exportDefinition);
        }

        private void BtnUploadDataClick(object sender, RibbonControlEventArgs e)
        {
            _exportSheetHandler.ExportData((Worksheet)Globals.ThisWorkbook.ActiveSheet);
        }

        private void BtnDownloadDataClick(object sender, RibbonControlEventArgs e)
        {
            _exportSheetHandler.ImportData((Worksheet)Globals.ThisWorkbook.ActiveSheet);
        }
    }
}
