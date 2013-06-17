// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class DisciplineRepository : GeneralRepository<Discipline>, INamedRepository<Discipline>
    {
        #region INamedRepository<Discipline> Members

        public Discipline GetByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return (from disc in session.Query<Discipline>()
                        where disc.Name == name
                        select disc).SingleOrDefault();
            }
        }

        #endregion
    }
}