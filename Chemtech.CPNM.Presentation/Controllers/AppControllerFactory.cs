using System;
using Chemtech.CPNM.BR;
using Chemtech.CPNM.BR.DI;

namespace Chemtech.CPNM.Presentation.Controllers
{
    public static class AppControllerFactory
    {
        public static IAppController Create(string desiredController)
        {
            switch (desiredController)
            {
                case "AppWordController":
                    return DiResolver.IocResolve<IAppController>(); // TODO: Add Resolve ByName.
                //Todo: adicionar implementacao de outros controllers.
                default:
                    throw new Exception("invalid controller asked for");
            }
        }
    }
}