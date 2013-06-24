// ItemTypeGroupRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class SubAreaRepository : GeneralRepository<SubArea>, INamedRepository<SubArea>
    {
        #region INamedRepository<ItemTypeGroup> Members

        public SubArea GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<SubArea>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }

        #endregion

        public ICollection<SubArea> GetAllByProject(Project project)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from sb in session.Query<SubArea>()
                        where sb.Project.Id == project.Id
                        select sb).ToList();
            }
        }
    }
}