using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class ItemTypeGroup
    {
        public virtual Guid ItemTypeGroupKey { get; protected set; }
        public virtual string ItemGroupName { get; set; }
    }
}
