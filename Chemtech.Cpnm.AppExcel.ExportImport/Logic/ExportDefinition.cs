using System;
using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.Cpnm.AppExcel.ExportImport.Logic
{
    public class ExportDefinition
    {
        public ICollection<Property> Properties { get; set; }
        public ICollection<Item> Items { get; internal set; }
        public bool FetchAllItems { get; set; }

        private static ICollection<ItemType> _itemTypes;
        private static SubArea _subArea;

        public ICollection<ItemType> ItemTypes
        {
            get { return _itemTypes; }
            set
            {
                _itemTypes = value;
                var itemRepository = new ItemRepository();

                if (SubArea != null)
                    Items = (from itp in _itemTypes select itemRepository.GetByTypeAndSubArea(itp, SubArea)).SelectMany(x => x).ToList();
                else
                    Items = (from itp in _itemTypes select itemRepository.GetByType(itp)).SelectMany(x => x).ToList();
            }
        }

        public SubArea SubArea
        {
            get { return _subArea; }
            set
            {
                if (_subArea != null && Items != null)
                    throw new Exception("Nao eh permitido trocar a subarea quando os itens ja estao setados");
                if(Items!= null)
                    Items = Items.ToList().Where(it => Equals(it.SubArea, value)).ToList();

                _subArea = value;
            }
        }
    }
}
