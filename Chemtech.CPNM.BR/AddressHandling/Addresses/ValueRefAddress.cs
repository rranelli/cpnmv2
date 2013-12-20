using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.AddressHandling.Addresses
{
    public class ValueRefAddress : ItemRelatedAddress
    {
        private readonly UnitOfMeasure _unitOfMeasure;
        private readonly FormatType _formatType;
        private readonly Property _property;

        public ValueRefAddress(Item item, Property property, UnitOfMeasure unitOfMeasure, FormatType formatType)
        {
            Item = item;
            _property = property;
            _unitOfMeasure = unitOfMeasure;
            _formatType = formatType;
        }

        public override string GetAddressString()
        {
            return MakeAddress();
        }

        public override string GetValue()
        {
            return Item.GetPropValue(_property) != null
                       ? Item.GetPropValue(_property).FormatedValue(_unitOfMeasure, _formatType)
                       : "No Value";
        }

        private string MakeAddress() // TODO : move routerchar as a resource.
        {
            return GetPreffix(AddressType.ValueRef) + RouterChar + Item.Id + RouterChar +
                   _property.Id + RouterChar +
                        (_unitOfMeasure != null 
                            ? _unitOfMeasure.Id.ToString() 
                            : _property.DefaultUnit.Id.ToString())
                   + RouterChar + _formatType;
        }
    }
}