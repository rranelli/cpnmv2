using System.Collections.ObjectModel;
using Chemtech.CPNM.Model.Addresses;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface.ViewModels
{
    public interface IGetAddressViewModel
    {
        void Open();
        void Close();
        bool ResultOk();

        ObservableCollection<Item> Items { set; get; }
        ObservableCollection<ItemType> ItemTypes { set; get; }
        ObservableCollection<Property> Properties { get; set; }
        ObservableCollection<UnitOfMeasure> UnitOfMeasures { get; set; }
        ObservableCollection<ItemTypeGroup> ItemTypeGroups { get; set; }
        ObservableCollection<PropertyGroup> PropertyGroups { get; set; }
        ObservableCollection<SubArea> SubAreas { get; set; }

        PropValue.FormatType FormatTypes { get; set; }
        AddressDefiner.AddressType AddressType { get; set; }
        bool MetaSelected { get; set; }

        AddressDefiner GetAddressDefiner();
    }
}