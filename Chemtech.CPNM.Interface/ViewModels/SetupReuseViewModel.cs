using System.Collections.Generic;
using Chemtech.CPNM.BR.Logic;
using Chemtech.CPNM.Model.Domain;

<<<<<<< HEAD:Chemtech.CPNM.Interface/ViewModels/SetupReuseViewModel.cs
namespace Chemtech.CPNM.Interface.ViewModels
=======
namespace Chemtech.CPNM.Presentation.IViewsModels
>>>>>>> 5267e163de70384897acb9bb67abbbd054ebd0a7:Chemtech.CPNM.Presentation/IViewsModels/ISetupReuseView.cs
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
