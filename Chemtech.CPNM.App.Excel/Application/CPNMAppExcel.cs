using System;
using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.AddressHandling.Addresses;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Model.Domain;
using Microsoft.Office.Interop.Excel;

namespace Chemtech.CPNM.App.Excel.Application
{
    public class CPNMAppExcel : ICPNMApp
    {
        private readonly Microsoft.Office.Interop.Excel.Application _excelApp;
        private readonly IAddressFactory _addressObjFactory;

        public CPNMAppExcel(IAddressFactory addressObjFactory)
        {
            _addressObjFactory = addressObjFactory;
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
            IDictionary<int, IAddress> indexedReferences = new Dictionary<int, IAddress>();
            foreach(Name name in _excelApp.Names)
                if(IsCpnmRefVarName(name.Name)) 
                    indexedReferences.Add(GetIndexFromName(name.Name), _addressObjFactory.Create(name.RefersTo.ToString()));

            return indexedReferences;
        }

        public void ApplyMapping(IDictionary<int, IAddress> newMapping, bool isColorChanges)
        {
            // Importante. O caching do nhibernate n'ao recarrega os valores do banco quando eles sao alterados.
            foreach(Name name in _excelApp.Names)  //pqp, Names n'ao implementa ienumerable.... good lord.
            {
                if(IsCpnmRefVarName(name.Name))
                    name.RefersTo = newMapping[GetIndexFromName(name.Name)].GetAddressString();
                if (IsCpnmValueVarName(name.Name))
                    name.RefersTo = newMapping[GetIndexFromName(name.Name)].GetValue();
            }
        }

        public void UpdateAllReferences() // confia na implementacao de apply mapping
        {
            var currentIndexedReferences = GetIndexedReferences(false);
            var updatedIndexedReferences = new Dictionary<int, IAddress>();
            
            currentIndexedReferences.ToList()
                .ForEach(x => 
                    updatedIndexedReferences.Add(x.Key,
                                                _addressObjFactory
                                                .Create(x.Value.GetAddressString())));

            ApplyMapping(updatedIndexedReferences, true);
        }

        public ICollection<Item> GetReferencedItems()
        {
            return GetIndexedReferences(false).ToList().Select(kvp => kvp.Value.Item);
        }

        private int GetNextIndex() // todo: eliminar essa mutacao de maxindex.
        {
            var maxindex=0;
            foreach (Name name in _excelApp.Names)
            {
                var thisindex = Convert.ToInt32(GetIndexFromName(name.Name));
                if (thisindex > maxindex) maxindex = thisindex;
            }
            return maxindex + 1;
        }

        private static bool IsCpnmRefVarName(string cpnmRefVarName)
        {
            return cpnmRefVarName.Contains("cpnmref");
        }

        private static bool IsCpnmValueVarName(string cpnmValueVarName)
        {
            return cpnmValueVarName.Contains("cpnmval");
        }

        private static int GetIndexFromName(string cpnmRefVarName)
        {
            return Convert.ToInt16(cpnmRefVarName.Replace("cpnmref", "").Replace("cpnmval", ""));
        }
    }
}