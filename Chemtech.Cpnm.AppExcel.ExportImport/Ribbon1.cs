using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chemtech.Cpnm.AppExcel.ExportImport.Forms;
using Chemtech.Cpnm.AppExcel.ExportImport.Logic;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace Chemtech.Cpnm.AppExcel.ExportImport
{
    public partial class Ribbon1
    {
        private IExportSheetHandler exportSheetHandler;
        private SetUpExportWorkbook setUpForm;
        private ExportDefinition exportDefinition;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnConfig_Click(object sender, RibbonControlEventArgs e)
        {
            setUpForm.ShowDialog();
            if(setUpForm.DialogResult == DialogResult.OK)
            {
                var exportDefinition = exportDefinition
                                           {
                                               Properties = setUpForm.SelectedProperties,
                                               SubArea = setUpForm.SelectedSubArea,
                                               FetchAllItems = setUpForm.FetchAllItems
                                           };
                exportDefinition.ItemTypes = setUpForm.SelectedItemTypes;
                exportSheetHandler.FormatExport((Worksheet)Globals.ThisWorkbook.ActiveSheet, exportDefinition);
            }
        }

        private void btnUploadData_Click(object sender, RibbonControlEventArgs e)
        {
            exportSheetHandler.ExportData((Worksheet)Globals.ThisWorkbook.ActiveSheet);
        }

        private void btnDownloadData_Click(object sender, RibbonControlEventArgs e)
        {
            exportSheetHandler.ImportData((Worksheet)Globals.ThisWorkbook.ActiveSheet);
        }
    }
}
