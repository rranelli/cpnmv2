// PropertyGroupRepository.cs
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
    public interface IPropertyGroupRepository
    {
        PropertyGroup GetByName(string name);
        void Add(PropertyGroup ent);
        void Update(PropertyGroup ent);
        void Remove(PropertyGroup ent);
        PropertyGroup GetById(Guid id);
        ICollection<PropertyGroup> GetAll();
        IQueryable GetQueryable();
    }

    public class PropertyGroupRepository : GeneralRepository<PropertyGroup>, INamedRepository<PropertyGroup>, IPropertyGroupRepository
    {
        public PropertyGroupRepository(ISession session)
            : base(session)
        {
        }

        #region INamedRepository<PropertyGroup> Members

        public PropertyGroup GetByName(string name)
        {
            return (from ig in Session.Query<PropertyGroup>()
                    where ig.Name == name
                    select ig).SingleOrDefault();
        }

        #endregion
    }
}