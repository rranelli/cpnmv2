using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface.IApps
{
    public interface ICPNMAppCad : ICPNMApp
    {
        void InsertItemAsBlock(Item item);
    }
}