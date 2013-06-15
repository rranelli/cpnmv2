using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chemtech.CPNM.Model.Domain
{
    public class Discipline : Entity, INamed
    {
        public virtual string Name { get; set; }
    }
}