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

    public class DisciplineRepository : GeneralNamedRepository<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(ISession session)
            : base(session)
        {
        }
    }
}