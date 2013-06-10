using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public interface IUnitOfMeasure
    {
        Guid UnitKey { get; }
        string Symbol { get; set; }
        double ConvFactor { get; set; }
        double OffsetFactor { get; set; }
    }

    public class UnitOfMeasure : IUnitOfMeasure
    {
        public Guid UnitKey { get; protected set; }
        public string Symbol { get; set; }
        public double ConvFactor { get; set; }
        public double OffsetFactor { get; set; }
    }
}