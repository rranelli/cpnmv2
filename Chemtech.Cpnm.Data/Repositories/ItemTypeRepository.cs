// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class ItemTypeRepository : GeneralRepository<ItemType>, INamedRepository<ItemType>
    {
        #region INamedRepository<ItemType> Members

        public ItemType GetByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from it in session.Query<ItemType>()
                        where it.Name == name
                        select it).SingleOrDefault();
            }
        }

        #endregion

        public ICollection<ItemType> GetByGroup(ItemTypeGroup itemTypeGroup)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from it in session.Query<ItemType>()
                        where it.ItemTypeGroup.Id == itemTypeGroup.Id
                        select it).ToList();
            }
        }
    }
}