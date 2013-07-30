// ItemTypeRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public interface IItemTypeRepository
    {
        ItemType GetByName(string name);
        ICollection<ItemType> GetByGroup(ItemTypeGroup itemTypeGroup);
        void Add(ItemType ent);
        void Update(ItemType ent);
        void Remove(ItemType ent);
        ItemType GetById(Guid id);
        ICollection<ItemType> GetAll();
        IQueryable GetQueryable();
    }

    public class ItemTypeRepository : GeneralNamedRepository<ItemType>, INamedRepository<ItemType>, IItemTypeRepository
    {
        public ItemTypeRepository(ISession session)
            : base(session)
        {
        }

        public ICollection<ItemType> GetByGroup(ItemTypeGroup itemTypeGroup)
        {
            return (from it in Session.Query<ItemType>()
                    where it.ItemTypeGroup.Id == itemTypeGroup.Id
                    select it).ToList();
        }
    }
}