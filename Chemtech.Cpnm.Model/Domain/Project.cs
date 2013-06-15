using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chemtech.CPNM.Model.Domain
{
    public class Project : Entity, INamed
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
