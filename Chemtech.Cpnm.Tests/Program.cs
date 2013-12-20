using System;
using Castle.Windsor.Installer;
using Chemtech.CPNM.Tests.UnitTests;

namespace Chemtech.CPNM.Tests
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var container = new TestDIContainer();
            var testHelper = container.Resolve<ITestHelper>();

            var configuration = testHelper.MakeConfiguration();
            testHelper.SetUpDatabaseTestData(configuration);

            var appexcelz = new Microsoft.Office.Interop.Excel.Application {Visible = true};
            appexcelz.Workbooks.OpenText("c:/text.txt");
        }
    }
}