using System;
using System.Globalization;

namespace Chemtech.CPNM.Model.Domain
{
    public class ValueRef : Entity
    {
        public virtual string Value { get; set; }
    }
    
    public class PropValue : Entity
    {
        public enum FormatType { ValueAndUnit, Value, Unit }
        public virtual Xref Xref { get; set; }
        protected internal virtual ValueRef ValueRef { get; set; }
        
        public virtual Property GetProperty
        {
            get { return Xref.Property; }
        }

        public virtual string Value
        {
            get
            {
                if (ValueRef == null) ValueRef = new ValueRef();
                return ValueRef.Value;
            }
            set
            {
                if (ValueRef == null) ValueRef = new ValueRef();
                ValueRef.Value = value;
            }
        }

        public virtual bool IsConvertible()
        {
            double dummyParsed;
            if (GetProperty == null) return false;
            return GetProperty.IsConvertible() && double.TryParse(Value, out dummyParsed); //Try parse sera falso se value == null
        }

        public override string ToString()
        {
            return FormatedValue(FormatType.Value);
        }

        public virtual string FormatedValue(UnitOfMeasure desiredUnit, FormatType formatType)
        {
            if (!IsConvertible())
            {
                return Value;
            }

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

        public virtual string FormatedValue(FormatType formatType)
        {
            return FormatedValue(GetProperty.DefaultUnit, formatType);
        }

        public virtual void MakeShare(PropValue other)
        {
            if (!GetProperty.Dimension.Equals(other.GetProperty.Dimension)) throw new Exception("Dimensoes invalidas para o Share");
            ValueRef = other.ValueRef;
        }

        public virtual void BreakShare(PropValue other)
        {
            if (Equals(ValueRef, other.ValueRef))
            {
                ValueRef = new ValueRef() { Value = other.Value };
                if (Equals(ValueRef, other.ValueRef)) throw new Exception("BreakShare failed miserably.");
            }
        }

        private string ConvertValue(IUnitOfMeasure desiredUnit)
        {
            if (desiredUnit == null) throw new ArgumentNullException("desiredUnit");

            double valueAsDouble;
            double.TryParse(Value, out valueAsDouble); //TODO: Implementar opção de colocar casas decimais
            valueAsDouble = (valueAsDouble + desiredUnit.OffsetFactor) * desiredUnit.ConvFactor;
            return valueAsDouble.ToString(CultureInfo.InvariantCulture);
        }
    }
}