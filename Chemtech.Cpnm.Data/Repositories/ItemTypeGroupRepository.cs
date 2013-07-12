// ItemTypeGroupRepository.cs
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
    public interface IItemTypeGroupRepository
    {
        ItemTypeGroup GetByName(string name);
        void Add(ItemTypeGroup ent);
        void Update(ItemTypeGroup ent);
        void Remove(ItemTypeGroup ent);
        ItemTypeGroup GetById(Guid id);
        ICollection<ItemTypeGroup> GetAll();
        IQueryable GetQueryable();
    }

    public class ItemTypeGroupRepository : GeneralRepository<ItemTypeGroup>, INamedRepository<ItemTypeGroup>, IItemTypeGroupRepository
    {
        public ItemTypeGroupRepository(ISession session) : base(session)
        {
        }

        #region INamedRepository<ItemTypeGroup> Members

        public ItemTypeGroup GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<ItemTypeGroup>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }

        #endregion
    }
}