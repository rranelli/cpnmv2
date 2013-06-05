using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class PropertyGroup
    {
        public virtual Guid PropertyGroupKey { get; protected set; }
        public virtual string PropertyGroupName { set; get; }
        public virtual string Description { set; get; }
    }
}
