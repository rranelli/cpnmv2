using System;

namespace Chemtech.CPNM.Interface.Controllers
{
    public class AutoCadAppControllerBase : AppControllerBase
    {
        public AutoCadAppControllerBase(ICPNMApp cpnmApp) : base(cpnmApp) {}
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
