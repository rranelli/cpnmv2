using Chemtech.CPNM.BR;

namespace Chemtech.CPNM.Presentation.Controllers
{
    public interface IAppController
    {
        void InsertReferneceAction();
        void ApplyReferenceReuseAction();
        void UpdateReferencesAction();
    }

    public abstract class AppController : IAppController
    {
        protected ICPNMApp CPNMApp;

        protected AppController(ICPNMApp cpnmApp)
        {
            CPNMApp = cpnmApp;
        }

        public abstract void InsertReferneceAction();
        public abstract void ApplyReferenceReuseAction();
        public abstract void UpdateReferencesAction();
    }
}
