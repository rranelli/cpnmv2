using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class Dimension : Entity, INamed
    {
        public virtual string Name { get; set; }
        public virtual ICollection<UnitOfMeasure> Units { get; set; }
    }
}
