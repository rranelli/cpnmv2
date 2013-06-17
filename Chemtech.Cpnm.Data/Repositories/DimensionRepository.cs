// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class DimensionRepository : GeneralRepository<Dimension>, INamedRepository<Dimension>
    {
        #region INamedRepository<Dimension> Members

        public Dimension GetByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<Dimension>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }

        #endregion
    }
}