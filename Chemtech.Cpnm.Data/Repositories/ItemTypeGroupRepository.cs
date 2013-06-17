// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class ItemTypeGroupRepository : GeneralRepository<ItemTypeGroup>, INamedRepository<ItemTypeGroup>
    {
        #region INamedRepository<ItemTypeGroup> Members

        public ItemTypeGroup GetByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<ItemTypeGroup>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }

        #endregion
    }
}