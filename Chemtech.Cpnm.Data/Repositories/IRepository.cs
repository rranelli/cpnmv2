// IRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;

namespace Chemtech.CPNM.Data.Repositories
{
    public interface IRepository<T1>
    {
        void Add(T1 ent);
        void Update(T1 ent);
        void Remove(T1 ent);
        T1 GetById(Guid id);
    }
}