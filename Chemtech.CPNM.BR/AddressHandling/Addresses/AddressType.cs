using System.ComponentModel;

namespace Chemtech.CPNM.BR.AddressHandling.Addresses
{
    public enum AddressType
    {
        [Description("Valor")]
        ValueRef,
        [Description("Propriedade")]
        PropNameRef,
        [Description("Nome do Item")]
        ItemNameRef,
        [Description("Nome do Tipo do Item")]
        ItemTypeNameRef,
        [Description("�rea")]
        AreaRef,
        [Description("Sub �rea")]
        SubAreaRef,
        [Description("Projeto")]
        ProjectRef
    }
}