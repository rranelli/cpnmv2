﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPNMv2.Domain
{
    class ItemType : ItemTypeGroup
    {
        public Guid ItemTypeKey { get; protected set; }
        public string ItemTypeName { get; set; }
        protected List<Property> ValidProperties;
    }
}
