using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class UnitOfMeasure
    {
        public Guid UnitKey { get; protected set; }
        public string Symbol { get; set; }
        public double ConvFactor { get; set; }
        public double OffsetFactor { get; set; }
    }
}