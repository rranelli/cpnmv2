using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class ItemTypeGroup
    {
        public virtual Guid GroupKey { get; protected set; }
        public virtual string GroupName { get; set; }
        public virtual string GroupDescription { get; set; }
    }
}
