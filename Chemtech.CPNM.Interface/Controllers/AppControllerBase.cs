namespace Chemtech.CPNM.Interface.Controllers
{
    public abstract class AppControllerBase : IAppController
    {
        protected ICPNMApp CPNMApp;

        protected AppControllerBase(ICPNMApp cpnmApp)
        {
            CPNMApp = cpnmApp;
        }

        public abstract void InsertReferenceAction();
        public abstract void ApplyReferenceReuseAction();
        public abstract void UpdateReferencesAction();
    }
}
