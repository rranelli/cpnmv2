using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class ItemTypeGroupRepository : GeneralRepository<ItemTypeGroup>, INamedRepository<ItemTypeGroup>
    {
        public ItemTypeGroup GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<ItemTypeGroup>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }
    }
}
