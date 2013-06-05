using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using NHibernate;
using NHibernate.Linq;

namespace CPNMv2.Repositories
{
    class ItemRepository : IItemRepository
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

        public Item GetByID(Guid id)
        {
            using(ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Item>(id);
            }
        }
    }
}
