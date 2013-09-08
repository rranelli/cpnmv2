using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Interface.ViewModels;
using Chemtech.CPNM.Interface.Views;
using Chemtech.Cpnm.Data.Repositories;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AppOfficeControllerBase : AppControllerBase
    {
        private readonly IGetAddressViewModel _addressViewModel;
        private readonly IAddressFactory _addressFactory;
        private readonly ISetupReuseView _setupReuseView;

        public AppOfficeControllerBase(ICPNMApp cpnmApp, IGetAddressViewModel addressViewModel, IAddressFactory addressFactory, ISetupReuseView setupReuseView) : base(cpnmApp)
        {
            _addressViewModel = addressViewModel;
            _addressFactory = addressFactory;
            _setupReuseView = setupReuseView;
        }

        public override void InsertReferenceAction()
        {
            _addressViewModel.Open();
            if (!_addressViewModel.ResultOk()) return;
            var address = _addressFactory.Create(_addressViewModel.GetAddressDefiner());
            
            CPNMApp.InsertReference(address);
        }

        public override void ApplyReferenceReuseAction()
        {
            _setupReuseView.Open();
            if (!_setupReuseView.ResultOk()) return;
            
            var reuseHandler = _setupReuseView.GetReuseDefinition(); //gets reuse handler
            var refDic = CPNMApp.GetIndexedReferences(_setupReuseView.IsRestrictedToSelection); // gets the references
            
            var mappedRefDic = reuseHandler.MapReferenceDic(refDic); //maps the active references into the new ones
            CPNMApp.ApplyMapping(mappedRefDic, _setupReuseView.IsColorChanges);
        }

        public override void UpdateReferencesAction()
        {
            CPNMApp.UpdateAllReferences();
        }
    }
}