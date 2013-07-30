// Property.cs
// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 05/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System.Collections.Generic;

namespace Chemtech.CPNM.Model.Domain
{
    public class Property : NamedEntity
    {
        public virtual UnitOfMeasure DefaultUnit { get; set; }
        public virtual PropertyGroup PropertyGroup { get; set; }
        public virtual Dimension Dimension { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCalculated { get; protected set; }

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