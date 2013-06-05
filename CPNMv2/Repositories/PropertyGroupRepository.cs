using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using NHibernate;

namespace CPNMv2.Repositories
{
    public class PropertyGroupRepository
    {
        public void Add(PropertyGroup propertyGroup)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(propertyGroup);
                transaction.Commit();
            }
        }

        public PropertyGroup GetByID(Guid Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<PropertyGroup>(Id);
            }
        }
    }
}