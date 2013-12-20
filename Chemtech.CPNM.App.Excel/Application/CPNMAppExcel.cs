using System;
using System.Collections.Generic;
using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.AddressHandling.Addresses;
using Chemtech.CPNM.BR.Apps;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Chemtech.CPNM.App.Excel.Application
{
    public class CPNMAppExcel : CPNMAppBase
    {
        private readonly Microsoft.Office.Interop.Excel.Application _excelApp;

        public CPNMAppExcel(IAddressFactory addressObjFactory, MSExcel.Application appExcel)
        {
            AddressObjFactory = addressObjFactory;
            _excelApp = appExcel;
        }
        public override void InsertReference(IAddress address)
        {
            var nextIndex = GetNextIndex();
            _excelApp.Names.Add("cpnmref" + nextIndex, address.GetAddressString());
            _excelApp.Names.Add("cpnmval" + nextIndex, address.GetValue());
            _excelApp.ActiveCell.Value = "=cpnmval" + nextIndex;
        }

        public override IDictionary<int, IAddress> GetIndexedReferences(bool isRestrictedToSelection)
        {
            IDictionary<int, IAddress> indexedReferences = new Dictionary<int, IAddress>();
            foreach (MSExcel.Name name in _excelApp.Names)
                if (IsCpnmRefVarName(name.Name))
                    indexedReferences.Add(GetIndexFromName(name.Name), AddressObjFactory.Create(name.RefersTo.ToString()));

            return indexedReferences;
        }

        public override void ApplyMapping(IDictionary<int, IAddress> newMapping, bool isColorChanges)
        {
            foreach (MSExcel.Name name in _excelApp.Names) 
            {
                if (IsCpnmRefVarName(name.Name))
                    name.RefersTo = newMapping[GetIndexFromName(name.Name)].GetAddressString();
                if (IsCpnmValueVarName(name.Name))
                    name.RefersTo = newMapping[GetIndexFromName(name.Name)].GetValue();
            }
        }

        private int GetNextIndex()
        {
            var maxindex = 0;
            foreach (MSExcel.Name name in _excelApp.Names)
            {
                var thisindex = Convert.ToInt32(GetIndexFromName(name.Name));
                if (thisindex > maxindex) maxindex = thisindex;
            }
            return maxindex + 1;
        }

        private static int GetIndexFromName(string cpnmRefVarName)
        {
            return Convert.ToInt16(cpnmRefVarName.Replace("cpnmref", "").Replace("cpnmval", ""));
        }
    }
}