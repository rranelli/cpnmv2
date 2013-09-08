using System;
using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.Tests.UnitTests;

namespace Chemtech.CPNM.Tests
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var testHelper = DiResolver.IocResolve<ITestHelper>();
            var configuration = testHelper.MakeConfiguration();
            testHelper.SetUpDatabaseTestData(configuration);

            //var b = DiResolver.IocResolve<IGetAddressViewModel>();

            //b.Open();
        }
    }
}
