using System;
using System.Windows.Forms;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Presentation.Forms;
using Chemtech.Cpnm.Data.Addresses;

namespace Chemtech.CPNM.Presentation.Document
{
    public class AddressGetter
    {
        private Item _item;
        private PropValue _propValue;
        private PropValue.FormatType _formatType;
        private UnitOfMeasure _unitOfMeasure;
        
        private IAddressFactory _addressFactory;
        private GetReference _getReference;

        public AddressGetter(IAddressFactory addressFactory, GetReference getReference)
        {
            _addressFactory = addressFactory;
            _getReference = getReference;
        }

        public IAddress GetAddress()
        {
            _getReference.ShowDialog();
            if (_getReference.DialogResult != DialogResult.OK) return null;
            var addressDefiner = _getReference.GetAddressDefiner();
            return _addressFactory.Create(addressDefiner);
        }
    }
}
