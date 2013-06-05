using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    class PropValue : Property
    {
        public Guid ValueKey { get; protected set; }
        public string Value { get; set; }

        public override bool IsConvertible()
        {
            double dummyParsed;
            return base.IsConvertible() && double.TryParse(Value, out dummyParsed);
        }
    }
}