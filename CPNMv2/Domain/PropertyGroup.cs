using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class PropertyGroup : Entity, INamed
    {
        public virtual string Description { set; get; }
        public virtual  string Name { get; set; }
    }
}
