// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: 
// 6:17 PM

namespace Chemtech.CPNM.Model.Domain
{
    public class Xref : Entity
    {
        public virtual bool IsInternallyCalculated { get; set; }
        public virtual Property Property { get; set; }
    }
}