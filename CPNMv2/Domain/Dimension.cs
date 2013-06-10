using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class Dimension : Entity
    {
        public virtual ICollection<UnitOfMeasure> Units { get; set; }
    }
}
