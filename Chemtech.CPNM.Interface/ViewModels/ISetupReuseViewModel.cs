using System.Collections.Generic;
using Chemtech.CPNM.BR.ReuseLogic;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface.ViewModels
{
    public interface ISetupReuseViewModel : IViewModelBase
    {
        ICollection<Item> ExistantItems { set; get; }
        ICollection<Item> CandidateItems { get; set; }
        ICollection<Item> ItemStack { get; set; }

        bool IsRestrictedToSelection { get; set; }
        bool IsColorChanges { get; set; }

        IReuseHandler GetReuseDefinition();
    }
}
