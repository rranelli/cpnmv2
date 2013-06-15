using System.Collections.Generic;

namespace Chemtech.CPNM.Model.Domain
{
    public class Dimension : Entity, INamed
    {
        public virtual string Name { get; set; }
        public virtual ICollection<UnitOfMeasure> Units { get; set; }
    }
}
