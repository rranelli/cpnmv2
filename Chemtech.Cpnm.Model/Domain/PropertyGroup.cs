using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chemtech.CPNM.Model.Domain
{
    public class PropertyGroup : Entity, INamed
    {
        public virtual string Description { set; get; }
        public virtual  string Name { get; set; }
    }
}
