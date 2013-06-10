using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using NHibernate;
using NHibernate.Linq;

namespace CPNMv2.Repositories
{
    class ItemRepository : IRepository<Item>
    {
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
            using(ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Item>(id);
            }
        }

        public void Add(Item ent)
        {
            throw new NotImplementedException();
        }

        public void Update(Item ent)
        {
            throw new NotImplementedException();
        }

        public void Remove(Item ent)
        {
            throw new NotImplementedException();
        }
    }
}
