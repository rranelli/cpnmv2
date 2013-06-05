using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Domain;
using NHibernate;

namespace CPNMv2.Repositories
{
    public class ItemTypeGroupRepository
    {
        public void Add(ItemTypeGroup itemTypeGroup)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(itemTypeGroup);
                transaction.Commit();
            }
        }
    }
}
