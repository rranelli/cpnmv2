using Castle.MicroKernel.Registration;
using Chemtech.CPNM.App.Excel.Application;
using Chemtech.CPNM.BR.IApps;
using Chemtech.CPNM.Interface;

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
