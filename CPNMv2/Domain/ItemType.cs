using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class ItemType : Entity, INamed
    {
        public virtual ICollection<Property> ValidProperties { get; set; }
        public virtual ItemTypeGroup ItemTypeGroup { get; set; }
        public virtual Discipline OwnerDiscipline { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
    }
}