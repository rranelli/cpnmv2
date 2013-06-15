namespace Chemtech.CPNM.Model.Domain
{
    public class Xref : Entity
    {
        public virtual bool IsInternallyCalculated { get; set; }
        public virtual Property Property { get; set; }
    }
}