using System;
using System.Collections.Generic;
using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Model.Addresses;

namespace Chemtech.CPNM.App.Excel.Application
{
    public class CPNMAppExcel : ICPNMApp
    {
        private Microsoft.Office.Interop.Excel.Application _excelApp;

        public CPNMAppExcel()
        {
            _excelApp = Globals.ThisAddIn.Application;
        }

        public void InsertReference(IAddress address)
        {
            _excelApp.Names.Add(address.GetAddressString());
            _excelApp.ActiveCell.Value = "=" + address.GetAddressString();
        }

        public IDictionary<int, IAddress> GetIndexedReferences(bool isRestrictedToSelection)
        {
            throw new NotImplementedException();
        }

        public void ApplyMapping(IDictionary<int, IAddress> newMapping, bool isColorChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateAllReferences()
        {
            throw new NotImplementedException();
        }
    }
}
