// UnitOfMeasure.cs
// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 05/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

namespace Chemtech.CPNM.Model.Domain
{
    public class UnitOfMeasure : Entity, INamed
    {
        public virtual string Symbol { get; set; }
        public virtual double ConvFactor { get; set; }
        public virtual double OffsetFactor { get; set; }

        #region INamed Members

        public virtual string Name
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        #endregion
    }
}