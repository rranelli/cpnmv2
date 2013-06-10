using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    class Project : Entity
    {
        public string Name { set; get; }
        private IList<Item> _items;

        public IList<Item> GetAllItems()
        {
            return _items;
        }
    }
}
