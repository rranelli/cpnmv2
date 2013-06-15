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
                return (from ig in session.Query<ItemType>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }
    }
}