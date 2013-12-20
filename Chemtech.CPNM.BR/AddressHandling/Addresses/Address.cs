namespace Chemtech.CPNM.BR.AddressHandling.Addresses
{
    public interface IAddress {
        AddressType ThisAddressType { get; }
        string GetAddressString();
        string GetValue();
    }

    public abstract class Address : IAddress
    {
        protected string AddressString;
        // TODO : Move this block into resources. No configuration in file, jeeeez.
        protected const char RouterChar = '/'; // TODO: make this a resource.
        private const string CpnmAddressPreffix = "CPNM_#:"; // TODO: make this a resource.
        
        public AddressType ThisAddressType { get; protected set; }
        public abstract string GetAddressString();
        public abstract string GetValue();

        public static string GetPreffix(AddressType thisAddressType)
        {
            return CpnmAddressPreffix.Replace("#", thisAddressType.ToString());
        }
    }
}
