namespace Chemtech.CPNM.Interface.Controllers
{
    public interface IAppController
    {
        void InsertReferneceAction();
        void ApplyReferenceReuseAction();
        void UpdateReferencesAction();
    }

    public abstract class AppControllerBase : IAppController
    {
        protected ICPNMApp CPNMApp;

        protected AppControllerBase(ICPNMApp cpnmApp)
        {
            CPNMApp = cpnmApp;
        }

        public abstract void InsertReferneceAction();
        public abstract void ApplyReferenceReuseAction();
        public abstract void UpdateReferencesAction();
    }
}
