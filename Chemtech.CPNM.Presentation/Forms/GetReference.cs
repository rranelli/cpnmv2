// GetReference.cs
// Projeto: Chemtech.CPNM.UI
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 16/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Presentation.Forms
{
    public partial class GetReference : Form 
    {
        private readonly ICollection<ItemTypeGroup> _itemTypeGroups;
        private readonly ICollection<PropertyGroup> _propertyGroups;
        public PropValue.FormatType SelectedFormat;
        public PropValue SelectedPropValue;
        public Item SelectedItem;
        public UnitOfMeasure SelectedUnit;
        public bool IsMetaDataSelected { get; internal set; }
        public string SelectedMetaData
        {
            get
            {
                if(rbMetadata.Checked) return ltbMeta.SelectedItem.ToString();
                return null;
            }
        }

        public GetReference()
        {
            InitializeComponent();
            GetSelectedFormat();

            _itemTypeGroups = new ItemTypeGroupRepository().GetAll();
            _propertyGroups = new PropertyGroupRepository().GetAll();

            _itemTypeGroups.ToList().ForEach(itg => cmbItemTypeGroup.Items.Add(itg));
            _propertyGroups.ToList().ForEach(pg => cmbPropGroup.Items.Add(pg));

            if(CpnmSession.Project!=null)
                new SubAreaRepository().GetAllByProject(CpnmSession.Project).ToList().ForEach(sb=>cmbSubArea.Items.Add(sb));
            else
                new SubAreaRepository().GetAll().ToList().ForEach(sb=>cmbSubArea.Items.Add(sb));

            ltbMeta.Hide();
            IsMetaDataSelected = false;
        }

        private void GetSelectedPropValue()
        {
            if (ltbItem.SelectedItem != null && ltbProperty.SelectedItem != null)
            {
                var selectedItem = ((Item) ltbItem.SelectedItem);
                var selectedProperty = (Property) ltbProperty.SelectedItem;
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
            SelectedUnit = (UnitOfMeasure) ltbUnit.SelectedItem;
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

        private void btnFinishSelection_Click(object sender, EventArgs e)
        {
            GetSelectedPropValue();
            GetSelectedFormat();
            GetSelectedUnit();

            if (SelectedPropValue != null || (SelectedMetaData != null && ltbItem.SelectedItem != null))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Selecione um Item e uma propriedade.");
            }
        }

        private void cmbItemTypeGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ltbItemType.Items.Clear();
            if (cmbItemTypeGroup.SelectedItem != null)
            {
                var itemTypesByGroup =
                    new ItemTypeRepository().GetByGroup((ItemTypeGroup) cmbItemTypeGroup.SelectedItem);
                itemTypesByGroup.ToList().ForEach(it => ltbItemType.Items.Add(it));
            }
        }

        private void ltbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ltbItem.Items.Clear();
            ltbProperty.Items.Clear();
            if (ltbItemType.SelectedItem != null)
            {
                var selectedItemType = (ItemType) ltbItemType.SelectedItem;
                selectedItemType.ValidProperties.ToList().ForEach(prop => ltbProperty.Items.Add(prop));

                // filtrando por projeto
                ICollection<Item> itemsByType;
                if (CpnmSession.Project != null)
                    itemsByType = new ItemRepository().GetByTypeAndProject(selectedItemType, CpnmSession.Project);
                else
                    itemsByType = new ItemRepository().GetByType(selectedItemType);

                itemsByType.ToList().ForEach(i => ltbItem.Items.Add(i));
            }
        }

        private void ltbProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedPropValue();
            SetTextboxCurrentValue();
            ltbUnit.Items.Clear();

            if (ltbProperty.SelectedItem != null)
            {
                var property = ((Property) ltbProperty.SelectedItem);
                if (property.ValidUnits != null)
                    property.ValidUnits.ToList().ForEach(uni => ltbUnit.Items.Add(uni));
            }
        }

        private void ltbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedUnit();
            SetTextboxCurrentValue();
        }

        private void ltbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItem = (Item) ltbItem.SelectedItem;
            GetSelectedPropValue();
            SetTextboxCurrentValue();
        }

        private void rbValueOnly_CheckedChanged(object sender, EventArgs e)
        {
            SetTextboxCurrentValue();
        }

        private void rbValueAndUnit_CheckedChanged(object sender, EventArgs e)
        {
            SetTextboxCurrentValue();
        }

        private void rbUnitOnly_CheckedChanged(object sender, EventArgs e)
        {
            SetTextboxCurrentValue();
        }

        private void rbValueRef_CheckedChanged(object sender, EventArgs e)
        {
            ltbProperty.Show();
            ltbMeta.Hide();
            IsMetaDataSelected = false;
        }

        private void rbMetadata_CheckedChanged(object sender, EventArgs e)
        {
            ltbMeta.Show();
            ltbProperty.Hide();
            ltbProperty.SelectedItem = null;
            IsMetaDataSelected = true;
        }
    }
}