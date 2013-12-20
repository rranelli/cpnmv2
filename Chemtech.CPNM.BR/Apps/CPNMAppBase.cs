using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.AddressHandling.Addresses;
using Chemtech.CPNM.BR.IApps;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.Apps
{
    public abstract class CPNMAppBase : ICPNMApp
    {
        public abstract void InsertReference(IAddress address);
        public abstract void ApplyMapping(IDictionary<int, IAddress> newMapping, bool isColorChanges);
        public abstract IDictionary<int, IAddress> GetIndexedReferences(bool isRestrictedToSelection);

        protected IAddressFactory AddressObjFactory;

        public ICollection<Item> GetReferencedItems()
        {
            return GetIndexedReferences(false).Where(kvp => kvp.Value is ItemRelatedAddress)
                .Select(kvp => kvp.Value as ItemRelatedAddress)
                .Select(adr => adr.Item)
                .Distinct()
                .ToList();
        }

        protected static bool IsCpnmRefVarName(string cpnmRefVarName)
        {
            return cpnmRefVarName.Contains("cpnmref");
        }

        protected static bool IsCpnmValueVarName(string cpnmValueVarName)
        {
            return cpnmValueVarName.Contains("cpnmval");
        }

        public void UpdateAllReferences()
        {
            var currentIndexedReferences = GetIndexedReferences(false);
            var updatedIndexedReferences = new Dictionary<int, IAddress>();

            currentIndexedReferences.ToList()
                .ForEach(kvp => 
                    updatedIndexedReferences.Add(kvp.Key,
                                                 AddressObjFactory.Create(kvp.Value.GetAddressString())));

            ApplyMapping(updatedIndexedReferences, true);
        }
    }
}