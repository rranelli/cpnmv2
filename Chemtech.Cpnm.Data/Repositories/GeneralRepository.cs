using System;
using Chemtech.CPNM.Model.Domain;
using NHibernate;

namespace Chemtech.CPNM.Data.Repositories
{
    public class GeneralRepository<T> : IRepository<T>
    {
        public void Add(T ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(ent);
                transaction.Commit();
            }
        }

        public void Update(T ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(ent);
                transaction.Commit();
            }
        }

        public void Remove(T ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(ent);
                transaction.Commit();
            }
        }

        public T GetById(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (session.BeginTransaction())
            {
                return session.Get<T>(id);
            }
        }
    }
}
