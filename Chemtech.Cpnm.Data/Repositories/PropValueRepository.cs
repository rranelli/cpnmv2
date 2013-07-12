// PropValueRepository.cs
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
    public interface IPropValueRepository
    {
        PropValue GetByItemAndPropId(Guid itemId, Guid propId);
        void Update(PropValue propValue);
        void Add(PropValue ent);
        void Remove(PropValue ent);
        PropValue GetById(Guid id);
        ICollection<PropValue> GetAll();
        IQueryable GetQueryable();
    }

    public class PropValueRepository : GeneralRepository<PropValue>, IPropValueRepository
    {
        public PropValueRepository(ISession session)
            : base(session)
        {
        }

        public PropValue GetByItemAndPropId(Guid itemId, Guid propId)
        {
            {
                return (from pval in Session.Query<PropValue>()
                        where pval.Xref.Property.Id == propId && pval.ItemId == itemId
                        select pval).SingleOrDefault();
            }
        }

        public new void Update(PropValue propValue)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(propValue);
                transaction.Commit();
            }
        }
    }
}