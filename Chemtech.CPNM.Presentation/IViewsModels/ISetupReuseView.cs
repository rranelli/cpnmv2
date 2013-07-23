using System.Collections.Generic;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Presentation.IViews
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
    }
}
