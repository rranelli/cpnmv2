// ItemTypeRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class ItemTypeRepository : GeneralRepository<ItemType>, INamedRepository<ItemType>
    {
        #region INamedRepository<ItemType> Members

        public ItemType GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from it in session.Query<ItemType>()
                        where it.Name == name
                        select it).SingleOrDefault();
            }
        }

        #endregion

        public ICollection<ItemType> GetByGroup(ItemTypeGroup itemTypeGroup)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from it in session.Query<ItemType>()
                        where it.ItemTypeGroup.Id == itemTypeGroup.Id
                        select it).ToList();
            }
        }
    }
}