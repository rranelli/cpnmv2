using System.Collections.Generic;
using System.Linq;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.Cpnm.Data.DTOs
{
    public interface IItemGrid
    {
        ICollection<Property> Properties { get; }
        ICollection<Item> Items { get; }
    }

    public class ItemGrid : IItemGrid
    {
        private readonly ICollection<Item> _items;
        private readonly ICollection<Property> _properties;
        private readonly IDictionary<Property, UnitOfMeasure> _unitOfMeasures;

        public ItemGrid(ICollection<Item> items, ICollection<Property> properties, IDictionary<Property, UnitOfMeasure> unitOfMeasures)
        {
            _items = items;
            _properties = properties;
            _unitOfMeasures = unitOfMeasures;
        }

        public string[,] GetGridMatrix() // items in rows, properties in columns.
        {
            var temp = new string[_items.Count,_properties.Count];
            var i = 1;
            var j = 1;

            _items.ToList().ForEach(
                it =>
                    {
                        _properties
                            .ToList().ForEach(prp =>
                                                  {
                                                      var pval = it.GetPropValue(prp);
                                                      if (pval != null)
                                                      {
                                                          temp[i, j] =
                                                              pval.FormatedValue(_unitOfMeasures.ContainsKey(prp)
                                                                                     ? _unitOfMeasures[prp]
                                                                                     : prp.DefaultUnit,
                                                                                 PropValue.FormatType.ValueAndUnit);
                                                      }
                                                      j += 1;
                                                  });
                        i += 1;
                    }
                );
            return temp;
        }

        public ICollection<Property> Properties
        {
            get { return _properties; }
        }

        public ICollection<Item> Items
        {
            get { return _items; }
        }
    }
}
