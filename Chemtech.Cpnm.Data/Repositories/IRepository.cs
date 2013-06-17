// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

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