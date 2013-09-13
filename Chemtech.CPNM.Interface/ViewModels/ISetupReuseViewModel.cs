using System.Collections.ObjectModel;
using Chemtech.CPNM.BR.ReuseLogic;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface.ViewModels
{
    public interface ISetupReuseViewModel : IViewModelBase
    {
        ObservableCollection<Item> ExistantItems { set; get; }
        ObservableCollection<Item> CandidateItems { get; set; }
        ObservableCollection<ItemReusePair> ReuseQueue { get; set; }

        Item SelectedOrigin { get; set; }
        Item SelectedCandidate { get; set; }

        bool IsRestrictedToSelection { get; set; }
        bool IsColorChanges { get; set; }

        IReuseHandler GetReuseDefinition();
    }
}
