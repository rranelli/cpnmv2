using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class Xref : Entity
    {
        public virtual Property Property { get; set; }
        public virtual ItemType ItemType { get; set; }
    }
}