using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class PropertyGroup
    {
        public virtual Guid GroupKey { get; protected set; }
        public virtual string GroupName { set; get; }
        public virtual string GroupDescription { set; get; }
    }
}
