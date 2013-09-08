using System.Collections.Generic;
using Chemtech.CPNM.Model.Addresses;

namespace Chemtech.CPNM.Interface
{
    public interface ICPNMApp
    {
        // Assumption > The index is DOCUMENT DEPENDANT !!!!!

        // inserts a single text reference into the document.
        void InsertReference(IAddress address);

        // gets the references in the document as a dict. if IsRestric.. is true, you get back only the references in the active selection area.
        // All references must be stored in the document with a numerical index.
        IDictionary<int, IAddress> GetIndexedReferences(bool isRestrictedToSelection);

        // maps all references in the document using the indexed addresses into new addresses (item ref reuse).
        void ApplyMapping(IDictionary<int, IAddress> newMapping, bool isColorChanges); 

        // updates all values referenced into the document
        void UpdateAllReferences();
    }
}
