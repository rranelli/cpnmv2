using System.Collections.Generic;
using Chemtech.CPNM.BR.Logic;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Presentation.IViewsModels
{
    public interface ISetupReuseView
    {
        void Open();
        void Close();
        bool ResultOk();

        ICollection<Item> ExistantItems { set; get; }
        ICollection<Item> CandidateItems { get; set; }
        ICollection<Item> ItemStack { get; set; }
        bool IsRestrictedToSelection { get; set; }
        bool IsColorChanges { get; set; }

        IReuseHandler GetReuseDefinition();
    }
}
