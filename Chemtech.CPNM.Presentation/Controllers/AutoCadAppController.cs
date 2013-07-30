using System;

namespace Chemtech.CPNM.Presentation.Controllers
{
    public class AutoCadAppController : AppController
    {
        public AutoCadAppController(ICPNMApp cpnmApp) : base(cpnmApp) {}
        public override void InsertReferneceAction()
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
