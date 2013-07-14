// ReuseHandler.cs
// Projeto: Chemtech.CPNM.BR
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 17/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Data.DTOs;

namespace Chemtech.CPNM.BR.Logic
{
    public class ReuseHandler
    {
        private Dictionary<string, string> _mapOldToNew;
        private ICollection<ItemReusePair> _reusePairs;
        public bool IsSelectionRestricted { get; set; }

        public ICollection<ItemReusePair> ReusePairs
        {
            get { return _reusePairs; }
            set
            {
                _reusePairs = value;

                _mapOldToNew = new Dictionary<string, string>();
                _reusePairs.ToList().
                    ForEach(rp =>
                            _mapOldToNew.Add(rp.OldItem.Id.ToString(), rp.NewItem.Id.ToString()));
            }
        }

        public ICollection<Item> OldItems
        {
            get { return (from pair in ReusePairs select pair.OldItem).ToList(); }
        }

        public ICollection<Item> NewItems
        {
            get { return (from pair in ReusePairs select pair.NewItem).ToList(); }
        }

        public string SwapAddress(string addressToSwap)
        {
            if (_mapOldToNew == null) return null;

            foreach (var keyvalpair in _mapOldToNew)
                addressToSwap = addressToSwap.Replace(keyvalpair.Key, keyvalpair.Value);
            return addressToSwap;
        }
    }
}