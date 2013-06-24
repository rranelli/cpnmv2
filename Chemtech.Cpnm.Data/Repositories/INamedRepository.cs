// INamedRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

namespace Chemtech.CPNM.Data.Repositories
{
    internal interface INamedRepository<T>
    {
        T GetByName(string name);
    }
}