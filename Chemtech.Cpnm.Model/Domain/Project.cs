// Project.cs
// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 05/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

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