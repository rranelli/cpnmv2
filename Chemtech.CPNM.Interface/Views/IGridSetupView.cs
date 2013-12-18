using System.Collections.Generic;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface.Views
{
    public interface IGridSetupView
    {
        ICollection<ItemTypeGroup> ItemTypeGroups { get; set; }
        ICollection<PropertyGroup> PropertyGroups { get; set; }
        ICollection<ItemType> ItemTypes { get; set; }
        ICollection<Property> Properties { get; set; }
        ICollection<SubArea>  SubAreas { get; set; }
        bool IsFetchAllProps { get; set; }
        bool IsFetchAllItems { get; set; }
    }
}
