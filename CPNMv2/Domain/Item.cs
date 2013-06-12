using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPNMv2.Repositories;

namespace CPNMv2.Domain
{
    public class Item : Entity, INamed
    {
        public virtual Project Project { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string UniqueName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<PropValue> PropValues { get; set; }

        public virtual PropValue GetValue(Guid propId)
        {
            var propRepository = new PropertyRepository();
            return GetValue(propRepository.GetById(propId));
        }

        public virtual PropValue GetValue(string propName)
        {
            var propRepository = new PropertyRepository();
            return GetValue(propRepository.GetByName(propName));
        }

        public virtual PropValue GetValue(Property property)
        {
            // AssertIsValidProperty(property);
            var repository = new ItemRepository();
            var resultPropVal = repository.FetchPropValue(this, property);

            if (resultPropVal != null) //se encontrei no banco, vou adicionar aa colecao e retornar.
            {
                PropValues.Add(resultPropVal);
                return resultPropVal;
            }

            // se nao encontrei, vou ter de criar um novo.
            resultPropVal = new PropValue() { Property = property, ItemType = ItemType };
            PropValues.Add(resultPropVal);
            return resultPropVal;
        }

        private void AssertIsValidProperty(Property property)
        {
            if (!ItemType.ValidProperties.Contains(property) || property == null)
                throw new Exception("Propriedade invalida solicitada!");
        }
    }
}