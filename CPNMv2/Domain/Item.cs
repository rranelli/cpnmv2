using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    internal class Item : Entity
    {
        public Project Project { get; set; }
        public ItemType ItemType { get; set; }
        public string UniqueName;
        public string Description;
        public bool IsActive;
        private List<PropValue> _validProps;

        public List<PropValue> PropValues
        {
            get { return _validProps; }
            set // todo: Test this code.
            {
                foreach (var candidate in value)
                {
                    var thisProp = candidate.Property;
                    if(!ItemType.ValidProperties.Contains(thisProp))
                    {
                        throw new Exception("Setting invalid property into this Item.");
                    }
                    _validProps = value;
                }
            }
        }

        public PropValue GetValue(Guid propKey)
        {
            return (from propval in PropValues
                    where propval.Id == propKey
                    select propval).SingleOrDefault();
        }

        public PropValue GetValue(string propName)
        {
            return (from propval in PropValues
                    where propval.Property.Name == propName
                    select propval).SingleOrDefault();
        }

        public PropValue GetValue(Property property)
        {
            return (from propval in PropValues
                    where propval.Property.Equals(property)
                    select propval).SingleOrDefault();
        }

        public List<PropValue> GetAllPropValues()
        {
            return PropValues;
        }
    }
}