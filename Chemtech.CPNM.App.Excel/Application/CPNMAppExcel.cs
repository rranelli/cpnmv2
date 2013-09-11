using System;
using System.Collections;
using System.Collections.Generic;
using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Model.Addresses;

namespace Chemtech.CPNM.App.Excel.Application
{
    public class CPNMAppExcel : ICPNMApp
    {
        private readonly Microsoft.Office.Interop.Excel.Application _excelApp;

        public CPNMAppExcel()
        {
            _excelApp = Globals.ThisAddIn.Application;
        }

        public void InsertReference(IAddress address)
        {
            var nextIndex = GetNextIndex();
            _excelApp.Names.Add("cpnmref" + nextIndex, address.GetAddressString());
            _excelApp.Names.Add("cpnmval" + nextIndex, address.GetValue());
            _excelApp.ActiveCell.Value = "=cpnmval" + nextIndex;
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

        private int GetNextIndex()
        {
            var maxindex=0;
            foreach (var name in _excelApp.Names)
            {
                var thisindex = Convert.ToInt32(name.ToString().Replace("cpnmref", ""));
                if (thisindex > maxindex) maxindex = thisindex;
            }
            return maxindex + 1;
        }
    }
}

