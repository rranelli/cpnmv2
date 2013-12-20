using Chemtech.CPNM.BR.AddressHandling;
using Chemtech.CPNM.BR.IApps;
using Chemtech.CPNM.Interface.ViewModels;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AppControllerBase : IAppController
    {
        private readonly IGetAddressViewModel _addressViewModel;
        private readonly IAddressFactory _addressFactory;
        private readonly ISetupReuseViewModel _setupReuseViewModel;

        protected ICPNMApp CPNMApp;

        public AppControllerBase
            (ICPNMApp cpnmApp, IGetAddressViewModel addressViewModel, IAddressFactory addressFactory, ISetupReuseViewModel setupReuseViewModel)
        {
            CPNMApp = cpnmApp;
            _addressViewModel = addressViewModel;
            _addressFactory = addressFactory;
            _setupReuseViewModel = setupReuseViewModel;
        }

        public void InsertReferenceAction()
        {
            _addressViewModel.OpenViewDialog();
            if (!_addressViewModel.ResultOk()) return;
            var address = _addressFactory.Create(_addressViewModel.GetAddressDefiner());
            
            CPNMApp.InsertReference(address);
        }

        public void ApplyReferenceReuseAction()
        {
            _setupReuseViewModel.OpenViewDialog();
            if (!_setupReuseViewModel.ResultOk()) return;
            
            var reuseHandler = _setupReuseViewModel.GetReuseDefinition();                            //gets reuse handler
            var refDic = CPNMApp.GetIndexedReferences(_setupReuseViewModel.IsRestrictedToSelection); // gets the references
            
            var mappedRefDic = reuseHandler.MapReferenceDic(refDic);                                 //maps the active references into the new ones
            CPNMApp.ApplyMapping(mappedRefDic, _setupReuseViewModel.IsColorChanges);
        }

        public void UpdateReferencesAction()
        {
            CPNMApp.UpdateAllReferences();
        }
    }
}