using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.Apps
{
    public interface ICPNMAppCad : ICPNMApp
    {
        void InsertItemAsBlock(Item item);
    }
}