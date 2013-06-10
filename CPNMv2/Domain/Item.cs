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
        private List<PropValue> _propValues;

        public PropValue GetValue(Guid propKey)
        {
            return (from propval in _propValues
                    where propval.Id == propKey
                    select propval).SingleOrDefault();
        }

        public List<PropValue> GetAllPropValues()
        {
            return _propValues;
        }
    }
}