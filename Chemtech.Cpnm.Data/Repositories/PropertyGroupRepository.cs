using System;
using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;

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

    public class PropertyGroupRepository : GeneralNamedRepository<PropertyGroup>, IPropertyGroupRepository
    {
        public PropertyGroupRepository(ISession session)
            : base(session)
        {
        }
    }
}