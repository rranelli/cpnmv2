// Xref.cs
// Projeto: Chemtech.CPNM.Model
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 11/06/2013
// Modificado em: 18/06/2013 : 1:51 AM

namespace Chemtech.CPNM.Model.Domain
{
    public class Xref : Entity
    {
        public virtual bool IsInternallyCalculated { get; set; }
        public virtual Property Property { get; set; }
    }
}