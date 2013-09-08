using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface
{
    public interface ICPNMAppCad : ICPNMApp
    {
        void InsertItemAsBlock(Item item);
    }
}