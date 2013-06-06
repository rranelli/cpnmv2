using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    public class PropValue : Property
    {
        public Guid ValueKey { get; protected set; }
        public string Value { get; set; }

        public PropValue() {}

        public override bool IsConvertible()
        {
            double dummyParsed;
            return base.IsConvertible() && double.TryParse(Value, out dummyParsed);
        }

        public string GetFormatedValue(UnitOfMeasure desiredUnit, int RefOption)
        {
            if (!IsConvertible())
            {
                return Value;
            }
            else
            {
                switch (RefOption)
                {
                    case 1:
                        return ConvertValue(desiredUnit);
                    case 2:
                        return ConvertValue(desiredUnit) + " " + desiredUnit.Symbol;
                    case 3:
                        return desiredUnit.Symbol;
                    default:
                        throw new Exception("Opção para unidade inválida");
                }
            }
        }

        private string ConvertValue(UnitOfMeasure desiredUnit)
        {
            double valueAsDouble;
            double.TryParse(Value, out valueAsDouble); //TODO: Implementar opção de colocar casas decimais
            valueAsDouble = (valueAsDouble + desiredUnit.OffsetFactor) * desiredUnit.ConvFactor;
            return valueAsDouble.ToString(CultureInfo.InvariantCulture);
        }
    }
}