// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

namespace Chemtech.CPNM.Model.Domain
{
    public class PropertyGroup : Entity, INamed
    {
        public virtual string Description { set; get; }

        #region INamed Members

        public virtual string Name { get; set; }

        #endregion
    }
}