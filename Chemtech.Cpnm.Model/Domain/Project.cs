// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

using System.Collections.Generic;

namespace Chemtech.CPNM.Model.Domain
{
    public class Project : Entity, INamed
    {
        public virtual string Description { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        #region INamed Members

        public virtual string Name { get; set; }

        #endregion
    }
}