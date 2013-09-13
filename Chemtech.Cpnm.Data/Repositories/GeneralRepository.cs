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
    public interface IGeneralRepository<T1>
    {
        void Add(T1 ent);
        void Update(T1 ent);
        void Remove(T1 ent);
        T1 GetById(Guid id);
    }

    internal interface INamedRepository<out T>
    {
        T GetByName(string name);
    }

    public class GeneralNamedRepository<T> : GeneralRepository<T>, INamedRepository<T> where T : NamedEntity
    {
        public GeneralNamedRepository(ISession session) : base(session) {}

        public T GetByName(string name)
        {
            return (from i in Session.Query<T>()
                    where i.Name == name
                    select i).SingleOrDefault();
        }
    }

    public class GeneralRepository<T> : IGeneralRepository<T> where T : Entity
    {
        protected ISession Session;

        public GeneralRepository(ISession session)
        {
            Session = session;
        }

        #region IRepository<T> Members

        public void Add(T ent)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(ent);
                transaction.Commit();
            }
        }

        public void Update(T ent)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Update(ent);
                transaction.Commit();
            }
        }

        public void Remove(T ent)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Delete(ent);
                transaction.Commit();
            }
        }

        public T GetById(Guid id)
        {
            return Session.QueryOver<T>()
                .Where(x=> x.Id == id)
                .CacheMode(CacheMode.Ignore)
                .SingleOrDefault();
        }

        #endregion

        public ICollection<T> GetAll()
        {
            return (from ent in Session.Query<T>()
                    select ent).ToList();
        }

        public IQueryable GetQueryable()
        {
            return Session.Query<T>();
        }
    }
}