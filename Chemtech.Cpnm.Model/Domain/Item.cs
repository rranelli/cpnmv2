using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chemtech.CPNM.Model.Domain
{
    public class Item : Entity, INamed
    {
        public virtual string Name { get; set; }
        public virtual Project Project { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string UniqueName { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<PropValue> PropValues { get; set; }

        public virtual void SetPropValue(PropValue propValue)
        {
            PropValues.Add(propValue);
        }

        public virtual PropValue GetPropValue(Property property)
        {
            return (from pval in PropValues
                    where pval.GetProperty.Equals(property)
                    select pval).SingleOrDefault();
        }

        public virtual PropValue GetPropValue(string propName)
        {
            return (from pval in PropValues
                    where pval.GetProperty.Name == propName
                    select pval).SingleOrDefault();
        }

        public virtual PropValue GetNewPropValue(Property property)
        {
            if (!ItemType.AssertIsValidProperty(property)) throw new Exception("Tentativa de criar uma propriedade sem xref para o tipoitem");
            return new PropValue { Xref = ItemType.GetXref(property) };
        }
    }
}