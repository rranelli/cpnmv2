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
using Chemtech.Cpnm.Data.Addresses;

namespace Chemtech.CPNM.BR.Logic
{
    public class ReuseHandler
    {
        private readonly Dictionary<string, string> _mapOldToNew;
        private readonly ICollection<ItemReusePair> _reusePairs;
        private readonly IAddressFactory _addressFactory;

        public ReuseHandler(ICollection<ItemReusePair> itemReusePairs, IAddressFactory addressFactory)
        {
            _reusePairs = itemReusePairs;
            _addressFactory = addressFactory;

            _mapOldToNew = new Dictionary<string, string>();
            _reusePairs.ToList().
                ForEach(rp =>
                        _mapOldToNew.Add(rp.OldItem.Id.ToString(), rp.NewItem.Id.ToString()));
        }

        public ICollection<Item> OldItems
        {
            get { return (from pair in _reusePairs select pair.OldItem).ToList(); }
        }

        public ICollection<Item> NewItems
        {
            get { return (from pair in _reusePairs select pair.NewItem).ToList(); }
        }

        public IDictionary<int, IAddress> MapReferenceDic(IDictionary<int, IAddress> oldReferences)
        {
            return oldReferences.ToDictionary
                (kvp => kvp.Key, kvp => _addressFactory.Create(SwapAddress(kvp.Value.GetAddressString())));
        }

        private string SwapAddress(string addressToSwap)
        {
            return _mapOldToNew == null
                ? null
                : _mapOldToNew.Aggregate(addressToSwap, (current, keyvalpair) => current.Replace(keyvalpair.Key, keyvalpair.Value));
        }
    }
}