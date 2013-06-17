// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using System;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class PropertyRepository : IRepository<Property>
    {
        #region IRepository<Property> Members

        public void Add(Property entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public Property GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Property>(id);
            }
        }

        public void Update(Property entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }
        }

        public void Remove(Property entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        #endregion

        public Property GetByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<Property>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }
    }
}