using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    class Property
    {
        public Guid PropKey { get; protected set; }
        public UnitOfMeasure[] ValidUnits { get; protected set; }
        public UnitOfMeasure DefaultUnit { get; set; }
        public IList<Discipline> DisciplinesWithAccess { get; set; }

        public virtual bool IsConvertible()
        {
            return ValidUnits != null;
        }
    }
}