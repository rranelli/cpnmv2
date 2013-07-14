// Item.cs
// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 05/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Chemtech.CPNM.Model.Domain
{
    public class Item : Entity, INamed
    {
        private ICollection<PropValue> _propValues;

        public virtual ItemType ItemType { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string UniqueName { get; set; }
        public virtual string Description { get; set; }
        public virtual SubArea SubArea { get; set; }
        
        #region INamed Members

        public virtual string Name { get; set; }

        #endregion
        public virtual Project Project { get { return SubArea.Project; } }
        public new virtual string ToString() { return Name; }
        public virtual ICollection<PropValue> PropValues
        {
            get { return _propValues; }
            set { _propValues = value; }
        }

        public Item()
        {
            _propValues = new Collection<PropValue>();
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
            if (!ItemType.AssertIsValidProperty(property))
                throw new Exception("Tentativa de criar uma propriedade sem xref para o tipoitem");
            return new PropValue {ItemId = Id, Xref = ItemType.GetXref(property)};
        }
    }
}