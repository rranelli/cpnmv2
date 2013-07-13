// SetUpReuse.cs
// Projeto: Chemtech.CPNM.UI
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 17/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Data.DTOs;
/*
namespace Chemtech.CPNM.Presentation.Forms
{
    public partial class SetUpReuse : Form
    {
        public SetUpReuse()
        {
            InitializeComponent();
        }

        public SetUpReuse(IEnumerable<Item> existantItems)
        {
            InitializeComponent();
            existantItems.ToList().ForEach(it => ltbExistantItems.Items.Add(it));
        }

        public ICollection<ReusePair> ReusePairs
        {
            get { return (from ReusePair rp in ltbStack.Items select rp).ToList(); }
        }

        public bool IsSelectionOnly
        {
            get { return ckbSelectionOnly.Checked; }
        }

        private void ltbExistantItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ltbCandidateItems.Items.Clear();
            if (ltbExistantItems.SelectedItem != null)
            {
                var selectedItem = (Item) ltbExistantItems.SelectedItem;
                new ItemRepository().
                    GetByType(selectedItem.ItemType).ToList().
                    ForEach(it => ltbCandidateItems.Items.Add(it));
            }
        }

        private void btnAddToStack_Click(object sender, EventArgs e)
        {
            if (ltbCandidateItems.SelectedItem != null && ltbExistantItems.SelectedItem != null)
            {
                var oldItem = (Item) ltbExistantItems.SelectedItem;
                var newItem = (Item) ltbCandidateItems.SelectedItem;

                var newInStack =
                    !(from ReusePair rp in ltbStack.Items
                      where rp.OldItem.Equals(oldItem)
                      select rp.OldItem).ToList().Any();

                if (newInStack)
                    ltbStack.Items.Add(new ReusePair {OldItem = oldItem, NewItem = newItem});
                else
                {
                    MessageBox.Show("Voce nao pode adicionar o mesmo item origem 2 vezes.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um Item origem e um item destino");
            }
        }

        private void btnCommitReuse_Click(object sender, EventArgs e)
        {
            if (ltbStack.Items.Count > 0)
                DialogResult = DialogResult.OK;
        }

        private void btnRemoveFromStack_Click(object sender, EventArgs e)
        {
            if (ltbStack.SelectedItem != null) ltbStack.Items.Remove(ltbStack.SelectedItem);
        }
    }
}*/