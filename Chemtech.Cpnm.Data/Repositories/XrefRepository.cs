// XrefRepository.cs
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

namespace Chemtech.CPNM.Data.Repositories
{
    public interface IXrefRepository
    {
        void Add(Xref ent);
        void Update(Xref ent);
        void Remove(Xref ent);
        Xref GetById(Guid id);
        ICollection<Xref> GetAll();
        IQueryable GetQueryable();
    }

    public class XrefRepository : GeneralRepository<Xref>, IXrefRepository
    {
        public XrefRepository(ISession session)
            : base(session)
        {
        }
    }
}