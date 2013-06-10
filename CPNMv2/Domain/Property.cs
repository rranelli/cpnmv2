using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class Property : Entity
    {
        public virtual UnitOfMeasure DefaultUnit { get; set; }
        public virtual PropertyGroup PropertyGroup { get; set; }
        public virtual Dimension Dimension { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<UnitOfMeasure> ValidUnits
        {
            get
            {
                if (Dimension == null) return null;
                return Dimension.Units;
            }
        }

        public virtual bool IsConvertible()
        {
            return ValidUnits != null;
        }
    }
}