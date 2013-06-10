using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using CPNMv2.Domain;

namespace CPNMv2.Domain
{
    public interface IPropValue
    {
        string Value { get; set; }
        bool IsConvertible();
        Property Property { get; }
    }

    public class PropValue : Entity, IPropValue
    {
        public string Value { get; set; }
        public Property Property { get; set; }
        public enum FormatType {ValueAndUnit, Value, Unit}

        public bool IsConvertible()
        {
            double dummyParsed;
            return Property.IsConvertible() && double.TryParse(Value, out dummyParsed);
        }

        public string GetFormatedValue(UnitOfMeasure desiredUnit, FormatType formatType)
        {
            if (!IsConvertible())
            {
                return Value;
            }
            else
            {
                switch (formatType)
                {
                    case FormatType.ValueAndUnit:
                        return ConvertValue(desiredUnit) + " " + desiredUnit.Symbol;
                    case FormatType.Value:
                        return ConvertValue(desiredUnit);
                    case FormatType.Unit:
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