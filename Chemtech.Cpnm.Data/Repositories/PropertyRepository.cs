// PropertyRepository.cs
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
    public interface IPropertyRepository
    {
        void Add(Property entity);
        Property GetById(Guid id);
        void Update(Property entity);
        void Remove(Property entity);
        Property GetByName(string name);
        ICollection<Property> GetAll();
        IQueryable GetQueryable();
    }

    public class PropertyRepository : GeneralNamedRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(ISession session)
            : base(session)
        {
        }
    }
}