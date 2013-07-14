// ReusePair.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 17/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Data.DTOs
{
    public class ItemReusePair
    {
        public Item OldItem { get; set; }
        public Item NewItem { get; set; }

        public override string ToString()
        {
            return OldItem.Name + " ==> " + NewItem.Name;
        }
    }
}