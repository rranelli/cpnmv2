using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using NHibernate;
using NHibernate.Linq;

namespace CPNMv2.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        public PropValue FetchPropValue(Item item, Property property)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from pval in session.Query<PropValue>()
                        where pval.ItemType.Id == item.ItemType.Id && property.Id == pval.Property.Id
                        select pval).SingleOrDefault();
            }
        }

        public Item GetByName(string itemName)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from i in session.Query<Item>()
                        where i.UniqueName == itemName
                        select i).SingleOrDefault();
            }
        }

        public Item GetById(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Item>(id);
            }
        }

        public void Add(Item ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(ent);
                transaction.Commit();
            }
        }

        public void Update(Item ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(ent);
                transaction.Commit();
            }
        }

        public void Remove(Item ent)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(ent);
                transaction.Commit();
            }
        }
    }
}
