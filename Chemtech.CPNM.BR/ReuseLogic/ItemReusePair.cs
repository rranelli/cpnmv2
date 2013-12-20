// ReusePair.cs
// Projeto: Chemtech.CPNM.Data
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 17/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.BR.ReuseLogic
{
    public class ItemReusePair
    {
        public Item OldItem { get; private set; }
        public Item NewItem { get; private set; }
        public string Name { get { return ToString(); }}

        public ItemReusePair(Item oldItem, Item newItem)
        {
            NewItem = newItem;
            OldItem = oldItem;
        }

        public override string ToString()
        {
            return OldItem.Name + " ==> " + NewItem.Name;
        }
    }
}