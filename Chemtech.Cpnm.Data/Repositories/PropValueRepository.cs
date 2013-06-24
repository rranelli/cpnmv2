// PropValueRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class PropValueRepository : GeneralRepository<PropValue>
    {
        public PropValue GetByItemAndPropId(Guid itemId, Guid propId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from pval in session.Query<PropValue>()
                        where pval.Xref.Property.Id == propId && pval.ItemId == itemId
                        select pval).SingleOrDefault();
            }
        }

        public new void Update(PropValue propValue)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(propValue);
                transaction.Commit();
            }
        }
    }
}