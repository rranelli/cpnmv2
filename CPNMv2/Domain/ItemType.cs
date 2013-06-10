using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    class ItemType : Entity
    {
        public string Name { get; set; }
        public List<Property> ValidProperties { get; set; }
        public IList<Discipline> DisciplinesWithAccess { get; set; }
    }
}