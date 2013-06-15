namespace Chemtech.CPNM.Model.Domain
{
    public interface IUnitOfMeasure
    {
        string Symbol { get; set; }
        double ConvFactor { get; set; }
        double OffsetFactor { get; set; }
    }

    public class UnitOfMeasure : Entity, IUnitOfMeasure
    {
        public virtual string Symbol { get; set; }
        public virtual double ConvFactor { get; set; }
        public virtual double OffsetFactor { get; set; }
    }
}