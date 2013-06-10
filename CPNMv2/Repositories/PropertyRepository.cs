using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using NHibernate;
using NHibernate.Linq;

namespace CPNMv2.Repositories
{
    public class PropertyRepository : IRepository<Property>
    {
        public Property GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<Property>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }

        public void Add(Property entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public Property GetById(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Property>(id);
            }
        }

        public void Update(Property entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }
        }

        public void Remove(Property entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }
    }
}