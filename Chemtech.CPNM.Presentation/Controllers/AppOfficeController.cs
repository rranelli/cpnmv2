using Chemtech.CPNM.BR;
using Chemtech.CPNM.Presentation.IViewsModels;
using Chemtech.CPNM.App.Excel.Data.Repositories;

namespace Chemtech.CPNM.Presentation.Controllers
{

    // TODO: nao ha necessidade de um appoffice controler. todos os metodos podem ser colocados na classe abstrata appcontroller e oficceappcontroller nao extende nada.
    public class AppOfficeController : AppController
    {
        private readonly IGetAddressView _addressView;
        private readonly IAddressFactory _addressFactory;
        private readonly ISetupReuseView _setupReuseView;

        public AppOfficeController(ICPNMApp cpnmApp, IGetAddressView addressView, IAddressFactory addressFactory, ISetupReuseView setupReuseView) : base(cpnmApp)
        {
            _addressView = addressView;
            _addressFactory = addressFactory;
            _setupReuseView = setupReuseView;
        }

        public override void InsertReferneceAction()
        {
            _addressView.Open();
            if (!_addressView.ResultOk()) return;
            var address = _addressFactory.Create(_addressView.GetAddressDefiner());
            
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
