using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel;
using Chemtech.CPNM.App.Excel;
using Chemtech.CPNM.BR.AddressHandling.Addresses;
using Chemtech.CPNM.BR.Apps;
using Chemtech.CPNM.Data.Repositories;
using Chemtech.CPNM.Model.Domain;
using Microsoft.Office.Interop.Excel;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests.AppExcel
{
    public class AppExcelFixture
    {
        private const string TestFilePath = "c:/users/renan/exceltest.txt";

        private Application _appExcel;
        private TestDIContainer _container;
        private ITestHelper _testHelper;
        private Configuration _configuration;
        private ICPNMApp _cpnmAppExcel;
        private IItemRepository _itemRepository;
        private IPropertyRepository _propertyRepository;

        [TestFixtureSetUp]
        public void Fixture()
        {
            _container = new TestDIContainer();
            _testHelper = _container.Resolve<ITestHelper>();
            _configuration = _testHelper.MakeConfiguration();

            _itemRepository = _container.Resolve<IItemRepository>();
            _propertyRepository = _container.Resolve<IPropertyRepository>();
        }

        [SetUp]
        public void Setup()
        {
            _testHelper.SetUpDatabaseTestData(_configuration);
            _appExcel = new Application { Visible = false, DisplayAlerts = false};
            
            _appExcel.Workbooks.OpenText(TestFilePath);

            _cpnmAppExcel = new AppExcelDIContainer().Resolve<ICPNMApp>(new Arguments(new { appExcel = _appExcel }));
        }

        [TearDown]
        public void TearDown()
        {
            _appExcel.Quit();
        }

        [Test]
        [STAThread]
        public void CanInsertReference()
        {
            var thisItem = _itemRepository.GetByName("Complex2");
            var thisProp = _propertyRepository.GetByName("prop3");

            _appExcel.ActiveWorkbook.ActiveSheet.Cells[1, 1].Select();
            _cpnmAppExcel.InsertReference(new ValueRefAddress(thisItem, thisProp, thisProp.DefaultUnit, FormatType.Value));

            Assert.AreEqual(_appExcel.Cells[1, 1].Text, thisItem.GetPropValue(thisProp).Value);
        }

        [Test]
        [STAThread]
        public void ApplyMappingCorrectlyForSingleRef()
        {
            var thisItem1 = _itemRepository.GetByName("Complex2");
            var thisItem2 = _itemRepository.GetByName("Complex");
            var thisProp = _propertyRepository.GetByName("prop3");

            var adr1 = new ValueRefAddress(thisItem1, thisProp, thisProp.DefaultUnit, FormatType.Value);
            var adr2 = new ValueRefAddress(thisItem2, thisProp, thisProp.DefaultUnit, FormatType.Value);

            _appExcel.ActiveWorkbook.ActiveSheet.Cells[1, 1].Select();
            _cpnmAppExcel.InsertReference(adr1);

            _cpnmAppExcel.ApplyMapping(new Dictionary<int, IAddress> { { 1, adr2 } }, false);

            Assert.AreEqual(_appExcel.Cells[1, 1].Text, adr2.GetValue());
        }

        [Test]
        [STAThread]
        public void CanGetIndexedReferencesAfterInsert()
        {
            var thisItem1 = _itemRepository.GetByName("Complex2");
            var thisProp = _propertyRepository.GetByName("prop3");

            var adr1 = new ValueRefAddress(thisItem1, thisProp, thisProp.DefaultUnit, FormatType.Value);

            _appExcel.ActiveWorkbook.ActiveSheet.Cells[1, 1].Select();
            _cpnmAppExcel.InsertReference(adr1);

            Assert.IsTrue(_cpnmAppExcel.GetIndexedReferences(false)
                                       .Select(kvp => kvp.Value.GetValue())
                                       .Contains(adr1.GetValue()));
        }

        [Test]
        [STAThread]
        public void CanGetReferencedItems()
        {
            var thisItem1 = _itemRepository.GetByName("Complex2");
            var thisProp = _propertyRepository.GetByName("prop3");

            var adr1 = new ValueRefAddress(thisItem1, thisProp, thisProp.DefaultUnit, FormatType.Value);

            _appExcel.ActiveWorkbook.ActiveSheet.Cells[1, 1].Select();
            _cpnmAppExcel.InsertReference(adr1);

            Assert.IsTrue(_cpnmAppExcel.GetReferencedItems()
                                       .Select(kvp=>kvp.Name)
                                       .Contains(adr1.Item.Name));
        }
    }
}
