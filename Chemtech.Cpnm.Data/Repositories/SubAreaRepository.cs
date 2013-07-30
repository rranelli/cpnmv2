// ItemTypeGroupRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public interface ISubAreaRepository
    {
        SubArea GetByName(string name);
        ICollection<SubArea> GetAllByProject(Project project);
        void Add(SubArea ent);
        void Update(SubArea ent);
        void Remove(SubArea ent);
        SubArea GetById(Guid id);
        ICollection<SubArea> GetAll();
        IQueryable GetQueryable();
    }

    public class SubAreaRepository : GeneralNamedRepository<SubArea>, ISubAreaRepository
    {
        public SubAreaRepository(ISession session)
            : base(session)
        {
        }

        public ICollection<SubArea> GetAllByProject(Project project)
        {
            return (from sb in Session.Query<SubArea>()
                    where sb.Project.Id == project.Id
                    select sb).ToList();
        }
    }
}