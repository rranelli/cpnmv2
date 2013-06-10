using System;

namespace CPNMv2.Repositories
{
    public interface IRepository<T1>
    {
        void Add(T1 ent);
        void Update(T1 ent);
        void Remove(T1 ent);
        T1 GetById(Guid id);
        T1 GetByName(string name);
    }
}