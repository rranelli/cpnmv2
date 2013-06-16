using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class ItemTypeRepository : GeneralRepository<ItemType>, INamedRepository<ItemType>
    {
        public ItemType GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from it in session.Query<ItemType>()
                        where it.Name == name
                        select it).SingleOrDefault();
            }
        }

        public ICollection<ItemType> GetByGroup(ItemTypeGroup itemTypeGroup)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from it in session.Query<ItemType>()
                        where it.ItemTypeGroup.Id == itemTypeGroup.Id
                        select it).ToList();
            }
        }
    }
}