// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:18 PM

namespace Chemtech.CPNM.Data.Repositories
{
    internal interface INamedRepository<T>
    {
        T GetByName(string name);
    }
}