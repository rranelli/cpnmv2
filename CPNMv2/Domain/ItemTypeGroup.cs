using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class ItemTypeGroup : Entity, INamed
    {
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
    }
}
