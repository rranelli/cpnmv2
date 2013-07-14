using Chemtech.CPNM.Model.Domain;

namespace Chemtech.Cpnm.Data.Addresses
{
    public class ValueRefAddress : Address
    {
        private readonly PropValue _propValue;
        private readonly UnitOfMeasure _unitOfMeasure;
        private readonly PropValue.FormatType _formatType;
        
        public ValueRefAddress(PropValue propValue, UnitOfMeasure unitOfMeasure, PropValue.FormatType formatType)
        {
            _propValue = propValue;
            _unitOfMeasure = unitOfMeasure;
            _formatType = formatType;

            AddressString = MakeAddress();
        }

        public override string GetValue()
        {
            return _propValue.FormatedValue(_unitOfMeasure, _formatType);
        }

        private string MakeAddress() // TODO : move routerchar as a resource.
        {
            return GetPreffix(AddressDefiner.AddressType.ValueRef) + RouterChar + _propValue.ItemId + RouterChar +
                       _propValue.GetProperty.Id + RouterChar +
                       (_unitOfMeasure != null
                            ? _unitOfMeasure.Id.ToString()
                            : _propValue.GetProperty.DefaultUnit.Id.ToString())
                       + RouterChar + _formatType;
        }
    }
}