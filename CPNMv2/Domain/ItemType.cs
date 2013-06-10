using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    class ItemType : Entity
    {
        public virtual List<Property> ValidProperties { get; set; }
        public virtual ItemTypeGroup ItemTypeGroup { get; set; }
        public virtual Discipline OwnerDiscipline { get; set; }
        public virtual string Description { get; set; }
    }
}