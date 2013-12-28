using Chemtech.Cpnm.Data.DTOs;

namespace Chemtech.CPNM.BR.Apps
{
    public interface ICPNMImportExport : ICPNMApp
    {
        void Upload(IItemGrid itemGrid); // este metodo supoe a reconstrucao do itemgrid apos alteracoes
        void SetupWorksheet(IItemGrid itemGrid);
        IItemGrid GetItemGrid(); // get item grid object with modified stuff
        void MarkDoubleUpload(); // marks double upload of shared values.
    }
}