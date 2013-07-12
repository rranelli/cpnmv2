// XrefRepository.cs
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
    public interface IUnitOfMeasureRepository
    {
        UnitOfMeasure GetByName(string name);
        void Add(UnitOfMeasure ent);
        void Update(UnitOfMeasure ent);
        void Remove(UnitOfMeasure ent);
        UnitOfMeasure GetById(Guid id);
        ICollection<UnitOfMeasure> GetAll();
        IQueryable GetQueryable();
    }

    public class UnitOfMeasureRepository : GeneralRepository<UnitOfMeasure>, INamedRepository<UnitOfMeasure>, IUnitOfMeasureRepository
    {
        public UnitOfMeasureRepository(ISession session)
            : base(session)
        {
        }

        public UnitOfMeasure GetByName(string name)
        {
            return (from uom in Session.Query<UnitOfMeasure>()
                    where uom.Symbol == name
                    select uom).SingleOrDefault();
        }
    }
}