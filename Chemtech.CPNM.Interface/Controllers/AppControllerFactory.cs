using System;

namespace Chemtech.CPNM.Interface.Controllers
{
    public static class AppControllerFactory
    {
        public static IAppController Create(string desiredController)
        {
            switch (desiredController)
            {
                case "AppWordController":
                    return new InterfaceDIContainer().Resolve<IAppController>(); // TODO: Add Resolve ByName.
                //Todo: adicionar implementacao de outros controllers.
                default:
                    throw new Exception("invalid controller asked for");
            }
        }
    }
}