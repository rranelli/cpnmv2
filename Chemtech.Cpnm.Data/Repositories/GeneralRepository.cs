// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class GeneralRepository<T> : IRepository<T>
    {
        #region IRepository<T> Members

        public void Add(T ent)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(ent);
                transaction.Commit();
            }
        }

        public void Update(T ent)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(ent);
                transaction.Commit();
            }
        }

        public void Remove(T ent)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(ent);
                transaction.Commit();
            }
        }

        public T GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (session.BeginTransaction())
            {
                return session.Get<T>(id);
            }
        }

        #endregion

        public ICollection<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from ent in session.Query<T>()
                        select ent).ToList();
            }
        }

        public IQueryable GetQueryable()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<T>();
            }
        }
    }
}