// ItemType.cs
// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 05/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

using System.Collections.Generic;
using System.Linq;

namespace Chemtech.CPNM.Model.Domain
{
    public class ItemType : Entity, INamed
    {
        public virtual ItemTypeGroup ItemTypeGroup { get; set; }
        public virtual Discipline OwnerDiscipline { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Xref> ValidXrefs { get; set; }

        public virtual ICollection<Property> ValidProperties
        {
            get { return ValidXrefs.ToList().Select(x => x.Property).ToList(); }
        }

        #region INamed Members

        public virtual string Name { get; set; }

        #endregion

        public virtual Xref GetXref(Property property)
        {
            return (from xref in ValidXrefs
                    where xref.Property.Equals(property)
                    select xref).SingleOrDefault();
        }

        public virtual bool AssertIsValidProperty(Property property)
        {
            return (from xref in ValidXrefs
                    where xref.Property.Equals(property)
                    select xref).Any();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}