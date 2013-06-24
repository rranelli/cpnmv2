// XrefRepository.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 15/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System.Linq;
using Chemtech.CPNM.Model.Domain;
using NHibernate.Linq;

namespace Chemtech.CPNM.Data.Repositories
{
    public class UnitOfMeasureRepository : GeneralRepository<UnitOfMeasure>, INamedRepository<UnitOfMeasure>
    {
        public UnitOfMeasure GetByName(string name)
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                return (from uom in session.Query<UnitOfMeasure>()
                        where uom.Symbol == name
                        select uom).SingleOrDefault();
            }
        }
    }
}