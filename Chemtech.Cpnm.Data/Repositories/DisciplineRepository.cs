// DisciplineRepository.cs
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
    public interface IDisciplineRepository
    {
        Discipline GetByName(string name);
        void Add(Discipline ent);
        void Update(Discipline ent);
        void Remove(Discipline ent);
        Discipline GetById(Guid id);
        ICollection<Discipline> GetAll();
        IQueryable GetQueryable();
    }

    public class DisciplineRepository : GeneralRepository<Discipline>, INamedRepository<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(ISession session)
            : base(session)
        {
        }

        #region INamedRepository<Discipline> Members

        public Discipline GetByName(string name)
        {
            return (from disc in Session.Query<Discipline>()
                    where disc.Name == name
                    select disc).SingleOrDefault();
        }

        #endregion
    }
}