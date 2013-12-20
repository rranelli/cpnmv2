using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.AddressHandling.Addresses
{
    public abstract class ItemRelatedAddress : Address
    {
        public Item Item { get; protected set; }
    }
}
