using System;
using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class ItemRepository : GeneralRepository<Item>, INamedRepository<Item>
    {
        public ICollection<PropValue> GetAllPropValues(Item item)
        {
            var fromDb = GetById(item.Id);
            NHibernateUtil.Initialize(fromDb);
            return fromDb.PropValues;
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

        public new void Update(Item item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(item);
                transaction.Commit();
            }
        }

        public ICollection<Item> GetAllByProject(Project project)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from i in session.Query<Item>()
                        where i.Project.Equals(project)
                        select i).ToList();
            }
        }
    }
}
