using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class Property : Entity
    {
        public UnitOfMeasure[] ValidUnits { get; set; }
        public UnitOfMeasure DefaultUnit { get; set; }
        public IList<Discipline> DisciplinesWithAccess { get; set; }

        public virtual bool IsConvertible()
        {
            return ValidUnits != null;
        }
    }
}