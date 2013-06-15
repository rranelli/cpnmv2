using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class PropertyGroupRepository : GeneralRepository<PropertyGroup>, INamedRepository<PropertyGroup> 
    {
        public PropertyGroup GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<PropertyGroup>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }
    }
}