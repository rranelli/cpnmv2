using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.IApps
{
    public interface ICPNMAppCad : ICPNMApp
    {
        void InsertItemAsBlock(Item item);
    }
}