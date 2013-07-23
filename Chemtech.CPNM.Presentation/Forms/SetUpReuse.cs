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


namespace Chemtech.CPNM.Presentation.Forms
{
    public partial class SetUpReuse
    {
        private readonly IItemRepository _itemRepository;

        public SetUpReuse(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            InitializeComponent();
        }

        public SetUpReuse(IEnumerable<Item> existantItems, IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            InitializeComponent();
            existantItems.ToList().ForEach(it => ltbExistantItems.Items.Add(it));
        }

        public ICollection<ItemReusePair> ReusePairs
        {
            get { return (from ItemReusePair rp in ltbStack.Items select rp).ToList(); }
        }

        public bool IsSelectionOnly
        {
            get { return ckbSelectionOnly.Checked; }
        }

        private void LtbExistantItemsSelectedIndexChanged(object sender, EventArgs e)
        {
            ltbCandidateItems.Items.Clear();
            if (ltbExistantItems.SelectedItem != null)
            {
                var selectedItem = (Item) ltbExistantItems.SelectedItem;
                _itemRepository.
                    GetByType(selectedItem.ItemType).ToList().
                    ForEach(it => ltbCandidateItems.Items.Add(it));
            }
        }

        private void BtnAddToStackClick(object sender, EventArgs e)
        {
            if (ltbCandidateItems.SelectedItem == null || ltbExistantItems.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Item origem e um item destino");
            }
            else
            {
                var oldItem = (Item) ltbExistantItems.SelectedItem;
                var newItem = (Item) ltbCandidateItems.SelectedItem;

                var newInStack =
                    !(from ItemReusePair rp in ltbStack.Items
                      where rp.OldItem.Equals(oldItem)
                      select rp.OldItem).ToList().Any();

                if (!newInStack)
                {
                    MessageBox.Show("Voce nao pode adicionar o mesmo item origem 2 vezes.");
                }

                else ltbStack.Items.Add(new ItemReusePair {OldItem = oldItem, NewItem = newItem});
            }
        }

        private void BtnCommitReuseClick(object sender, EventArgs e)
        {
            if (ltbStack.Items.Count > 0)
                DialogResult = DialogResult.OK;
        }

        private void BtnRemoveFromStackClick(object sender, EventArgs e)
        {
            if (ltbStack.SelectedItem != null) ltbStack.Items.Remove(ltbStack.SelectedItem);
        }

        private void ckbSelectionOnly_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}