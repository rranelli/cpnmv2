// DimensionRepository.cs
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
    public interface IDimensionRepository
    {
        Dimension GetByName(string name);
        void Add(Dimension ent);
        void Update(Dimension ent);
        void Remove(Dimension ent);
        Dimension GetById(Guid id);
        ICollection<Dimension> GetAll();
        IQueryable GetQueryable();
    }

    public class DimensionRepository : GeneralRepository<Dimension>, INamedRepository<Dimension>, IDimensionRepository
    {
        public DimensionRepository(ISession session) : base(session)
        {
        }

        #region INamedRepository<Dimension> Members

        public Dimension GetByName(string name)
        {
            return (from ig in Session.Query<Dimension>()
                    where ig.Name == name
                    select ig).SingleOrDefault();
        }

        #endregion
    }
}