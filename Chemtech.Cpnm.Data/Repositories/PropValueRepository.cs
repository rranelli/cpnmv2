// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using System;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class PropValueRepository : GeneralRepository<PropValue>
    {
        public PropValue GetByItemAndPropId(Guid itemId, Guid propId)
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                return (from pval in session.Query<PropValue>()
                        where pval.Xref.Property.Id == propId && pval.ItemId == itemId
                        select pval).SingleOrDefault();
            }
        }
    }
}