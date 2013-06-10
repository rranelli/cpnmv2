using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public interface IUnitOfMeasure
    {
        string Symbol { get; set; }
        double ConvFactor { get; set; }
        double OffsetFactor { get; set; }
    }

    public class UnitOfMeasure : Entity, IUnitOfMeasure
    {
        public virtual string Symbol { get; set; }
        public virtual double ConvFactor { get; set; }
        public virtual double OffsetFactor { get; set; }
    }
}