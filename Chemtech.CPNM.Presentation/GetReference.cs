// Projeto: Chemtech.CPNM.UI
// Solution: Chemtech.CPNM
// Implementado por: Renan Ranelli
// 6:18 PM

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Tests.UnitTests;

namespace Chemtech.CPNM.Presentation
{
    public partial class GetReference : Form
    {
        public PropValue SelectedPropValue;
        public UnitOfMeasure SelectedUnit;
        public PropValue.FormatType SelectedFormat;
        private ICollection<ItemTypeGroup> _itemTypeGroups;
        private ICollection<PropertyGroup> _propertyGroups;

        public GetReference()
        {
            InitializeComponent();

            GetSelectedFormat();

            _itemTypeGroups = new ItemTypeGroupRepository().GetAll();
            _propertyGroups = new PropertyGroupRepository().GetAll();

            _itemTypeGroups.ToList().ForEach(itg => cmbItemTypeGroup.Items.Add(itg));
            _propertyGroups.ToList().ForEach(pg => cmbPropGroup.Items.Add(pg));
        }

        private void GetSelectedPropValue()
        {
            if (ltbItem.SelectedItem != null && ltbProperty.SelectedItem != null)
            {
                var selectedItem = ((Item)ltbItem.SelectedItem);
                var selectedProperty = (Property)ltbProperty.SelectedItem;
                SelectedPropValue = selectedItem.GetPropValue(selectedProperty) ??
                                    selectedItem.GetNewPropValue(selectedProperty);
            }
            else
            {
                SelectedPropValue = null;
            }
        }

        private void GetSelectedFormat()
        {
            if (rbValueAndUnit.Checked)
                SelectedFormat = PropValue.FormatType.ValueAndUnit;
            if (rbValueOnly.Checked)
                SelectedFormat = PropValue.FormatType.Value;
            if (rbUnitOnly.Checked)
                SelectedFormat = PropValue.FormatType.Unit;
        }

        private void GetSelectedUnit()
        {
            SelectedUnit = (UnitOfMeasure)ltbUnit.SelectedItem;
        }

        private void SetTextboxCurrentValue()
        {
            GetSelectedFormat();
            txbValue.Text = null;

            if (SelectedPropValue != null)
            {
                txbValue.Text = SelectedPropValue.FormatedValue(SelectedUnit, SelectedFormat);
            }
        }

        private void btnFinishSelection_Click(object sender, System.EventArgs e)
        {
            GetSelectedPropValue();
            GetSelectedFormat();
            GetSelectedUnit();

            if (SelectedPropValue != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Selecione um Item e uma propriedade.");
            }
        }

        private void cmbItemTypeGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ltbItemType.Items.Clear();
            if (cmbItemTypeGroup.SelectedItem != null)
            {
                var itemTypesByGroup = new ItemTypeRepository().GetByGroup((ItemTypeGroup)cmbItemTypeGroup.SelectedItem);
                itemTypesByGroup.ToList().ForEach(it => ltbItemType.Items.Add(it));
            }
        }

        private void ltbItemType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ltbItem.Items.Clear();
            ltbProperty.Items.Clear();
            if (ltbItemType.SelectedItem != null)
            {
                var selectedItemType = (ItemType)ltbItemType.SelectedItem;
                selectedItemType.ValidProperties.ToList().ForEach(prop => ltbProperty.Items.Add(prop));

                var itemsByType = new ItemRepository().GetByType(selectedItemType);
                itemsByType.ToList().ForEach(i => ltbItem.Items.Add(i));
            }
        }

        private void ltbProperty_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GetSelectedPropValue();
            SetTextboxCurrentValue();
            ltbUnit.Items.Clear();

            if (ltbProperty.SelectedItem != null)
            {
                var property = ((Property)ltbProperty.SelectedItem);
                if (property.ValidUnits != null)
                    property.ValidUnits.ToList().ForEach(uni => ltbUnit.Items.Add(uni));
            }
        }

        private void ltbUnit_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GetSelectedUnit();
            SetTextboxCurrentValue();
        }

        private void ltbItem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GetSelectedPropValue();
            SetTextboxCurrentValue();
        }

        private void rbValueOnly_CheckedChanged(object sender, System.EventArgs e)
        {
            SetTextboxCurrentValue();
        }

        private void rbValueAndUnit_CheckedChanged(object sender, System.EventArgs e)
        {
            SetTextboxCurrentValue();
        }

        private void rbUnitOnly_CheckedChanged(object sender, System.EventArgs e)
        {
            SetTextboxCurrentValue();
        }
    }
}