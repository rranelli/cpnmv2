using System.Collections.Generic;
using Chemtech.CPNM.Model.Addresses;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Presentation.IViewsModels
{
    public interface IGetAddressView
    {
        void Open();
        void Close();
        bool ResultOk();

        ICollection<Item> Items { set; get; }
        ICollection<Property> Properties { get; set; }
        ICollection<UnitOfMeasure> UnitOfMeasures { get; set; }
        ICollection<ItemTypeGroup> ItemTypeGroups { get; set; }
        ICollection<PropertyGroup> PropertyGroups { get; set; }
        ICollection<SubArea> Collection { get; set; }

        PropValue.FormatType FormatType { get; set; }
        AddressDefiner.AddressType AddressType { get; set; }
        bool MetaSelected { get; set; }

        AddressDefiner GetAddressDefiner();
    }
}
