// DisciplineRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class DisciplineRepository : GeneralRepository<Discipline>, INamedRepository<Discipline>
    {
        #region INamedRepository<Discipline> Members

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

        #endregion
    }
}