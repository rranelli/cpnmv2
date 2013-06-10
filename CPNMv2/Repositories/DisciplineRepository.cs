using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using NHibernate;
using NHibernate.Linq;

namespace CPNMv2.Repositories
{
    public class DisciplineRepository : IRepository<Discipline>
    {
        public void Add(Discipline ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(ent);
                transaction.Commit();
            }
        }

        public void Update(Discipline ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(ent);
                transaction.Commit();
            }
        }

        public void Remove(Discipline ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(ent);
                transaction.Commit();
            }
        }

        public Discipline GetById(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                return session.Get<Discipline>(id);
            }
        }

        public Discipline GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                return (from disc in session.Query<Discipline>()
                        where disc.Name == name
                        select disc).SingleOrDefault();
            }
        }
    }
}
