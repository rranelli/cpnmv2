using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Model.Addresses
{
    public class ValueRefAddress : Address
    {
        private readonly UnitOfMeasure _unitOfMeasure;
        private readonly PropValue.FormatType _formatType;
        private readonly Item _item;
        private readonly Property _property;
        
        public ValueRefAddress(Item item , Property property, UnitOfMeasure unitOfMeasure, PropValue.FormatType formatType)
        {
            _item = item;
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
            return _item.GetPropValue(_property) != null 
                ? _item.GetPropValue(_property).FormatedValue(_unitOfMeasure, _formatType)
                : "No Value";
        }

        private string MakeAddress() // TODO : move routerchar as a resource.
        {
            return GetPreffix(AddressDefiner.AddressType.ValueRef) + RouterChar + _item.Id + RouterChar +
                       _property.Id + RouterChar +
                       (_unitOfMeasure != null
                            ? _unitOfMeasure.Id.ToString()
                            : _property.DefaultUnit.Id.ToString())
                       + RouterChar + _formatType;
        }
    }
}