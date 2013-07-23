using System.Collections.Generic;
using Chemtech.CPNM.Model.Domain;
using Chemtech.Cpnm.Data.Addresses;
using Chemtech.Cpnm.Data.DTOs;

namespace Chemtech.CPNM.BR
{
    public interface ICPNMApp
    {
        // Assumption > The index is DOCUMENT DEPENDANT !!!!!

        // inserts a single text reference into the document.
        void InsertReference(IAddress address);

        // gets the references in the document as a dict. if IsRestric.. is true, you get back only the references in the active selection area.
        // All references must be stored in the document with a numerical index.
        IDictionary<int, IAddress> GetIndexedReferences(bool isRestrictedToSelection);

        // updates all references in the document using the indexed addresses.
        void ApplyMapping(IDictionary<int, IAddress> newMapping, bool isColorChanges); 
    }

    public interface ICPNMAppCad : ICPNMApp
    {
        void InsertItemAsBlock(Item item);
    }

    public interface ICPNMImportExport : ICPNMApp
    {
        void Upload(IItemGrid itemGrid); // este metodo supoe a reconstrucao do itemgrid apos alteracoes
        void SetupWorksheet(IItemGrid itemGrid);
        IItemGrid GetItemGrid(); // get item grid object with modified stuff
        void MarkDoubleUpload(); // marks double upload of shared values.
    }
}
