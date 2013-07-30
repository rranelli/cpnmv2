// ItemRepository.cs
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
    public interface IItemRepository
    {
        Item GetByName(string itemName);
        ICollection<PropValue> GetAllPropValues(Item item);
        void Update(Item item);
        ICollection<Item> GetAllByProject(Project project);
        ICollection<Item> GetByType(ItemType itemType);
        ICollection<Item> GetByTypeAndProject(ItemType itemType, Project project);
        ICollection<Item> GetByTypeAndSubArea(ItemType itemType, SubArea subArea);
        void Add(Item ent);
        void Remove(Item ent);
        Item GetById(Guid id);
        ICollection<Item> GetAll();
        IQueryable GetQueryable();
    }

    public class ItemRepository : GeneralNamedRepository<Item>, IItemRepository
    {
        public ItemRepository(ISession session) : base(session)
        {
        }

        public new Item GetByName(string itemName)
        {
                return (from i in Session.Query<Item>()
                        where i.UniqueName == itemName
                        select i).SingleOrDefault();
        }

        public ICollection<PropValue> GetAllPropValues(Item item)
        {
            var fromDb = GetById(item.Id);
            return fromDb.PropValues;
        }

        public new void Update(Item item)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(item);
                transaction.Commit();
            }
        }

        public ICollection<Item> GetAllByProject(Project project)
        {
            {
                return (from i in Session.Query<Item>()
                        where i.Project.Id == project.Id
                        select i).ToList();
            }
        }

        public ICollection<Item> GetByType(ItemType itemType)
        {
            {
                return (from i in Session.Query<Item>()
                        where i.ItemType.Id == itemType.Id
                        select i).ToList();
            }
        }

        public ICollection<Item> GetByTypeAndProject(ItemType itemType, Project project)
        {
            {
                return (from i in Session.Query<Item>()
                        where i.ItemType.Id == itemType.Id && i.Project.Id == project.Id 
                        select i).ToList();
            }
        }

        public ICollection<Item> GetByTypeAndSubArea(ItemType itemType, SubArea subArea)
        {
            {
                return (from i in Session.Query<Item>()
                        where i.SubArea.Id == subArea.Id  && i.ItemType.Id == itemType.Id
                        select i).ToList();
            }
        }
    }
}