using System;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class DimensionRepository : GeneralRepository<Dimension>, INamedRepository<Dimension>
    {
        public Dimension GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<Dimension>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }
    }
}
