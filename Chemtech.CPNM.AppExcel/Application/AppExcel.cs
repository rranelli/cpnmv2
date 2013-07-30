using System;
using System.Collections.Generic;
using Chemtech.CPNM.Model.Addresses;
using Chemtech.CPNM.Presentation;

namespace AppExcel.Application
{
    public class CPNMAppExcel : ICPNMApp
    {
        public void InsertReference(IAddress address)
        {
            throw new NotImplementedException();
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
