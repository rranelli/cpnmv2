// GeneralRepository.cs
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
    public class GeneralRepository<T> : IRepository<T> where T : Entity
    {
        #region IRepository<T> Members

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

        #endregion

        public ICollection<T> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from ent in session.Query<T>()
                        select ent).ToList();
            }
        }

        public IQueryable GetQueryable()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<T>();
            }
        }
    }
}