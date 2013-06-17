// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

namespace Chemtech.CPNM.Model.Domain
{
    public class UnitOfMeasure : Entity, INamed
    {
        public virtual string Symbol { get; set; }
        public virtual double ConvFactor { get; set; }
        public virtual double OffsetFactor { get; set; }

        public virtual string Name
        {
            get { return Symbol; }
            set { Symbol = value; }
        }
    }
}