using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.AddressHandling.Addresses
{
    public interface IAddressDefiner {
        Item Item { get; set; }
        Property Property { get; set; }
        PropValue PropValue { get; set; }
        UnitOfMeasure UnitOfMeasure { get; set; }
        FormatType FormatType { get; set; }
        AddressType ThisAddressType { get; set; }
    }

    public class AddressDefiner : IAddressDefiner
    {
        public Item Item { get; set; }
        public Property Property { get; set; }
        public PropValue PropValue { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public FormatType FormatType { get; set; }
        public bool IsMetadata { get; set; }
        public AddressType ThisAddressType { get; set; }

        public bool IsValid()
        {
            return ((Item != null && Property != null && UnitOfMeasure != null) || IsMetadata);
        }
    }
}
