using System;
using Castle.Windsor.Installer;
using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.Tests.UnitTests;

namespace Chemtech.CPNM.Tests
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var container = DiResolver.Getcontainer();
            container.Install(FromAssembly.Named("Chemtech.CPNM.Tests"));
            var testHelper = container.Resolve<ITestHelper>();

            var configuration = testHelper.MakeConfiguration();
            testHelper.SetUpDatabaseTestData(configuration);

            var appexcelz = new Microsoft.Office.Interop.Excel.Application();
            appexcelz.Visible = true;
            appexcelz.Workbooks.OpenText("c:/text.txt");
        }
    }
}
