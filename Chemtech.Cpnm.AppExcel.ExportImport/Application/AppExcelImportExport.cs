using System;
using AppExcel.Application;
using Chemtech.CPNM.App.Excel.Data.DTOs;
using Chemtech.CPNM.Presentation;

namespace Chemtech.Cpnm.AppExcel.ExportImport.Application
{
    public class AppExcelImportExport : CPNMAppExcel, ICPNMImportExport
    {
        public void Upload(IItemGrid itemGrid)
        {
            throw new NotImplementedException();
        }

        public void SetupWorksheet(IItemGrid itemGrid)
        {
            throw new NotImplementedException();
        }

        public IItemGrid GetItemGrid()
        {
            throw new NotImplementedException();
        }

        public void MarkDoubleUpload()
        {
            throw new NotImplementedException();
        }
    }
}
