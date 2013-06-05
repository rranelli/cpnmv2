using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    class Project
    {
        public Guid ProjectId { get; protected set; }
        public string Name { set; get; }
        private IList<Item> _items;

        public IList<Item> GetAllItems()
        {
            return _items;
        }
    }
}
