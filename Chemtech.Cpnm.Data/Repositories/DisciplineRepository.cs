using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class DisciplineRepository : GeneralRepository<Discipline>, INamedRepository<Discipline> 
    {
        public Discipline GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                return (from disc in session.Query<Discipline>()
                        where disc.Name == name
                        select disc).SingleOrDefault();
            }
        }
    }
}
