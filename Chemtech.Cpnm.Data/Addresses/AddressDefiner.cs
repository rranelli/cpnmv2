﻿using Chemtech.CPNM.Model.Domain;

namespace Chemtech.Cpnm.Data.Addresses
{
    public interface IAddressDefiner {
        Item Item { get; set; }
        Property Property { get; set; }
        PropValue PropValue { get; set; }
        UnitOfMeasure UnitOfMeasure { get; set; }
        PropValue.FormatType FormatType { get; set; }
        AddressDefiner.AddressType ThisAddressType { get; set; }
    }

    public class AddressDefiner : IAddressDefiner
    {
        public Item Item { get; set; }
        public Property Property { get; set; }
        public PropValue PropValue { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public PropValue.FormatType FormatType { get; set; }
        public bool IsMetadata { get; set; }
        public AddressType ThisAddressType { get; set; }

        public enum AddressType
        {
            ValueRef,
            PropNameRef,
            ItemNameRef,
            ItemTypeNameRef,
            AreaRef,
            SubAreaRef,
            ProjectRef
        }
    }
}
