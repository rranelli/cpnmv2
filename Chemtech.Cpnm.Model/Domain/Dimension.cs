// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

using System.Collections.Generic;

namespace Chemtech.CPNM.Model.Domain
{
    public class Dimension : Entity, INamed
    {
        public virtual ICollection<UnitOfMeasure> Units { get; set; }

        #region INamed Members

        public virtual string Name { get; set; }

        #endregion
    }
}