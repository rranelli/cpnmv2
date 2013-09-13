using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Interface.ViewModels;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AppOfficeControllerBase : AppControllerBase
    {
        private readonly IGetAddressViewModel _addressViewModel;
        private readonly IAddressFactory _addressFactory;
        private readonly ISetupReuseViewModel _setupReuseViewModel;

        public AppOfficeControllerBase(ICPNMApp cpnmApp, IGetAddressViewModel addressViewModel, IAddressFactory addressFactory, ISetupReuseViewModel setupReuseViewModel) : base(cpnmApp)
        {
            _addressViewModel = addressViewModel;
            _addressFactory = addressFactory;
            _setupReuseViewModel = setupReuseViewModel;
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
            _setupReuseViewModel.Open();
            if (!_setupReuseViewModel.ResultOk()) return;
            
            var reuseHandler = _setupReuseViewModel.GetReuseDefinition(); //gets reuse handler
            var refDic = CPNMApp.GetIndexedReferences(_setupReuseViewModel.IsRestrictedToSelection); // gets the references
            
            var mappedRefDic = reuseHandler.MapReferenceDic(refDic); //maps the active references into the new ones
            CPNMApp.ApplyMapping(mappedRefDic, _setupReuseViewModel.IsColorChanges);
        }

        public override void UpdateReferencesAction()
        {
            CPNMApp.UpdateAllReferences();
        }
    }
}