using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Data.Repositories
{
    interface INamedRepository<T>
    {
        T GetByName(string name);
    }
}
