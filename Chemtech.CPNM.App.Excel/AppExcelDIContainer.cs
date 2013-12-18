using Castle.MicroKernel.Registration;
using Chemtech.CPNM.App.Excel.Application;
using Chemtech.CPNM.Interface;
using Chemtech.CPNM.Interface.IApps;

namespace Chemtech.CPNM.App.Excel
{
    public class AppExcelDIContainer : InterfaceDIContainer
    {
        public AppExcelDIContainer()
        {
            Register(Component.For<ICPNMApp>().ImplementedBy<CPNMAppExcel>().Named("CPNMAppExcel"));
        }
    }
}
