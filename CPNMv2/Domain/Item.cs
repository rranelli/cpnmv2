using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    internal class Item : ItemType
    {
        public Guid ItemKey { get; protected set; }
        public string UniqueName;
        public string ItemName;
        public string Description;
        public bool IsActive;
        private List<PropValue> _propValues;

        public PropValue GetValue(Guid propKey)
        {
            return (from propval in _propValues
                    where propval.PropKey == propKey
                    select propval).SingleOrDefault();
        }
    }
}