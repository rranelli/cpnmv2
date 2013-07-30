﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Addresses;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface.ViewModels
{
    public interface IGetAddressViewModel
    {
        void Open();
        void Close();
        bool ResultOk();

        ObservableCollection<Item> Items { set; get; }
        ObservableCollection<ItemType> ItemTypes { set; get; }
        ObservableCollection<Property> Properties { get; set; }
        ObservableCollection<UnitOfMeasure> UnitOfMeasures { get; set; }
        ObservableCollection<ItemTypeGroup> ItemTypeGroups { get; set; }
        ObservableCollection<PropertyGroup> PropertyGroups { get; set; }
        ObservableCollection<SubArea> SubAreas { get; set; }

        PropValue.FormatType FormatTypes { get; set; }
        AddressDefiner.AddressType AddressType { get; set; }
        bool MetaSelected { get; set; }

        AddressDefiner GetAddressDefiner();
    }

    public class GetAddressViewModel : ViewModelBase, IGetAddressViewModel, INotifyPropertyChanged
    {
        public GetAddressViewModel(Window view)
            : base(view)
        {
            ItemTypes = new ObservableCollection<ItemType>(DiResolver.IocResolve<IItemTypeRepository>().GetAll());
            ItemTypeGroups = new ObservableCollection<ItemTypeGroup>(DiResolver.IocResolve<IItemTypeGroupRepository>().GetAll());
            PropertyGroups = new ObservableCollection<PropertyGroup>(DiResolver.IocResolve<IPropertyGroupRepository>().GetAll());
            SubAreas = new ObservableCollection<SubArea>(DiResolver.IocResolve<ISubAreaRepository>().GetAll());
        }

        private Property _selectedProperty;
        private Item _selectedItem;
        private UnitOfMeasure _selectedUnitOfMeasure;
        private ItemType _selectedItemType;
        private ItemTypeGroup _selectedItemTypeGroup;
        private PropertyGroup _selectedPropertyGroup;
        private SubArea _selectedSubArea;
        private PropValue.FormatType _selectedFormatType;
        private AddressDefiner.AddressType _selectedAddressType;

        private ObservableCollection<ItemType> _itemTypes;
        private ObservableCollection<Item> _items;
        private ObservableCollection<Property> _properties;
        private ObservableCollection<UnitOfMeasure> _unitOfMeasures;
        private ObservableCollection<ItemTypeGroup> _itemTypeGroups;
        private ObservableCollection<PropertyGroup> _propertyGroups;
        private ObservableCollection<SubArea> _subAreas;
        private PropValue.FormatType _formatTypes;
        private AddressDefiner.AddressType _addressType;
        private bool _metaSelected;

        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public ObservableCollection<ItemType> ItemTypes
        {
            get { return _itemTypes; }
            set
            {
                _itemTypes = value;
                OnPropertyChanged("ItemTypes");
            }
        }

        public ObservableCollection<Property> Properties
        {
            get { return _properties; }
            set
            {
                _properties = value;
                OnPropertyChanged("Properties");
            }
        }

        public ObservableCollection<UnitOfMeasure> UnitOfMeasures
        {
            get { return _unitOfMeasures; }
            set
            {
                _unitOfMeasures = value;
                OnPropertyChanged("UnitOfMeasures");
            }
        }

        public ObservableCollection<ItemTypeGroup> ItemTypeGroups
        {
            get { return _itemTypeGroups; }
            set
            {
                _itemTypeGroups = value;
                OnPropertyChanged("ItemTypeGroups");
            }
        }

        public ObservableCollection<PropertyGroup> PropertyGroups
        {
            get { return _propertyGroups; }
            set
            {
                _propertyGroups = value;
                OnPropertyChanged("PropertyGroups");
            }
        }

        public ObservableCollection<SubArea> SubAreas
        {
            get { return _subAreas; }
            set
            {
                _subAreas = value;
                OnPropertyChanged("SubAreas");
            }
        }

        public PropValue.FormatType FormatTypes
        {
            get { return _formatTypes; }
            set
            {
                _formatTypes = value;
                OnPropertyChanged("FormatTypes");
            }
        }

        public AddressDefiner.AddressType AddressType
        {
            get { return _addressType; }
            set
            {
                _addressType = value;
                OnPropertyChanged("AddressType");
            }
        }

        public bool MetaSelected
        {
            get { return _metaSelected; }
            set
            {
                _metaSelected = value;
                OnPropertyChanged("MetaSelected");
            }
        }

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public Property SelectedProperty
        {
            get { return _selectedProperty; }
            set
            {
                _selectedProperty = value;
                OnPropertyChanged("SelectedProperty");
            }
        }

        public UnitOfMeasure SelectedUnitOfMeasure
        {
            get { return _selectedUnitOfMeasure; }
            set
            {
                _selectedUnitOfMeasure = value;
                OnPropertyChanged("SelectedUnitOfMeasure");
            }
        }

        public ItemType SelectedItemType
        {
            get { return _selectedItemType; }
            set
            {
                _selectedItemType = value;
                OnPropertyChanged("SelectedItemType");
            }
        }

        public ItemTypeGroup SelectedItemTypeGroup
        {
            get { return _selectedItemTypeGroup; }
            set
            {
                _selectedItemTypeGroup = value;
                ItemTypes = value != null ?
                      new ObservableCollection<ItemType>(DiResolver.IocResolve<IItemTypeRepository>().GetByGroup(_selectedItemTypeGroup))
                    : new ObservableCollection<ItemType>(DiResolver.IocResolve<IItemTypeRepository>().GetAll());

                OnPropertyChanged("SelectedItemTypeGroup");
            }
        }

        public PropertyGroup SelectedPropertyGroup
        {
            get { return _selectedPropertyGroup; }
            set
            {
                _selectedPropertyGroup = value;
                OnPropertyChanged("SelectedPropertyGroup");
            }
        }

        public SubArea SelectedSubArea
        {
            get { return _selectedSubArea; }
            set
            {
                _selectedSubArea = value;
                OnPropertyChanged("SelectedSubArea");
            }
        }

        public PropValue.FormatType SelectedFormatType
        {
            get { return _selectedFormatType; }
            set
            {
                _selectedFormatType = value;
                OnPropertyChanged("SelectedFormatType");
            }
        }

        public AddressDefiner.AddressType SelectedAddressType
        {
            get { return _selectedAddressType; }
            set
            {
                _selectedAddressType = value;
                OnPropertyChanged("SelectedAddressType");
            }
        }

        // ############
        // Property Chagned Event Handling
        // ############
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool ResultOk()
        {
            throw new System.NotImplementedException();
        }

        public AddressDefiner GetAddressDefiner()
        {
            throw new System.NotImplementedException();
        }
    }
}