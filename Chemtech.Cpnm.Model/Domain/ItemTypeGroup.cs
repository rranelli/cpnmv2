// ItemTypeGroup.cs
// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 05/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

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