namespace Chemtech.CPNM.Model.Domain
{
    public class SubArea : Entity, INamed
    {
        public virtual Project Project { get; set; }
        public virtual string Name { get; set; }
    }
}
