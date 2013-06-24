﻿// DimensionRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class DimensionRepository : GeneralRepository<Dimension>, INamedRepository<Dimension>
    {
        #region INamedRepository<Dimension> Members

        public Dimension GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return (from ig in session.Query<Dimension>()
                        where ig.Name == name
                        select ig).SingleOrDefault();
            }
        }

        #endregion
    }
}