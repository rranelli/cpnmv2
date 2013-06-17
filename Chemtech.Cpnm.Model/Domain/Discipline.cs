// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

namespace Chemtech.CPNM.Model.Domain
{
    public class Discipline : Entity, INamed
    {
        #region INamed Members

        public virtual string Name { get; set; }

        #endregion
    }
}