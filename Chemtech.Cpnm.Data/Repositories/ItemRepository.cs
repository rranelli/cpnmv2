// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class ItemRepository : GeneralRepository<Item>, INamedRepository<Item>
    {
        #region INamedRepository<Item> Members

        public Item GetByName(string itemName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from i in session.Query<Item>()
                        where i.UniqueName == itemName
                        select i).SingleOrDefault();
            }
        }

        #endregion

        public ICollection<PropValue> GetAllPropValues(Item item)
        {
            var fromDb = GetById(item.Id);
            NHibernateUtil.Initialize(fromDb);
            return fromDb.PropValues;
        }

        public new void Update(Item item)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(item);
                transaction.Commit();
            }
        }

        public ICollection<Item> GetAllByProject(Project project)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return (from i in session.Query<Item>()
                        where i.Project.Id == project.Id
                        select i).ToList();
            }
        }

        public ICollection<Item> GetByType(ItemType itemType)
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                return (from i in session.Query<Item>()
                        where i.ItemType.Id == itemType.Id
                        select i).ToList();
            }
        }
    }
}