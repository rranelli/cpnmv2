// GetReference.cs
// Projeto: Chemtech.CPNM.UI
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 16/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Collections.Generic;
using System.Windows.Forms;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Presentation.IViews;
using Chemtech.Cpnm.Data.Addresses;

namespace Chemtech.CPNM.Presentation.Forms
{
    public partial class GetReference : Form, IGetAddressView
    {
        public void Open()
        {
            ShowDialog();
        }

        public bool ResultOk()
        {
            return DialogResult == DialogResult.OK;
        }

        public ICollection<Item> Items { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<UnitOfMeasure> UnitOfMeasures { get; set; }
        public ICollection<ItemTypeGroup> ItemTypeGroups { get; set; }
        public ICollection<PropertyGroup> PropertyGroups { get; set; }
        public ICollection<SubArea> Collection { get; set; }
        public PropValue.FormatType FormatType { get; set; }
        public AddressDefiner.AddressType AddressType { get; set; }
        public bool MetaSelected { get; set; }
    }
}