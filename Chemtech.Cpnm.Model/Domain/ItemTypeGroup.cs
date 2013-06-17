// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

namespace Chemtech.CPNM.Model.Domain
{
    public class ItemTypeGroup : Entity, INamed
    {
        public virtual string Description { get; set; }

        #region INamed Members

        public virtual string Name { get; set; }

        #endregion
    }
}