using System;
using Chemtech.CPNM.Interface.IApps;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AppAutoCadController : AppControllerBase
    {
        public AppAutoCadController(ICPNMApp cpnmApp) : base(cpnmApp) {}
        public override void InsertReferenceAction()
        {
            throw new NotImplementedException();
        }

        public override void ApplyReferenceReuseAction()
        {
            throw new NotImplementedException();
        }

        public override void UpdateReferencesAction()
        {
            throw new NotImplementedException();
        }
    }
}
