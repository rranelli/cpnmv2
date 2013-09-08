using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.BR.Logic;
using Chemtech.CPNM.Interface;
using Chemtech.CPNM.Interface.Controllers;
using Chemtech.CPNM.Interface.IApps;
using Chemtech.CPNM.Interface.ViewModels;
using Chemtech.CPNM.Interface.Views;
using Chemtech.CPNM.Model.Addresses;
using Chemtech.Cpnm.Data.Repositories;
using NHibernate.Cfg;
using Rhino.Mocks;
using NUnit.Framework;

namespace Chemtech.CPNM.Tests.UnitTests.AppControllers
{
    class AppOfficeControllerFixture
    {
        private IGetAddressViewModel _addressViewModelMock;
        private IAddressFactory _addressFactoryMock;
        private ISetupReuseView _setupReuseViewMock;
        private IReuseHandler _reuseHandlerMock;
        private ICPNMApp _appMock;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            _addressFactoryMock = MockRepository.GenerateMock<IAddressFactory>();
            _addressFactoryMock.Expect(x => x.Create((IAddressDefiner) null)).IgnoreArguments().Return(null);

            _setupReuseViewMock = MockRepository.GenerateMock<ISetupReuseView>();
            _setupReuseViewMock.Expect(x => x.Open());
            _setupReuseViewMock.Expect(x => x.Close());
            _setupReuseViewMock.Expect(x => x.ResultOk()).Return(true);

            _addressViewModelMock = MockRepository.GenerateMock<IGetAddressViewModel>();
            _addressViewModelMock.Expect(x => x.Open());
            _addressViewModelMock.Expect(x => x.Close());
            _addressViewModelMock.Expect(x => x.ResultOk()).Return(true);
            _addressViewModelMock.Expect(x => x.GetAddressDefiner()).Return(null);

            _appMock = MockRepository.GenerateMock<ICPNMApp>();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void MustCallAppInsertReference()
        {
            _appMock.Expect(x => x.InsertReference(null));

            var controller = new AppOfficeControllerBase(_appMock, _addressViewModelMock, _addressFactoryMock,
                                                         _setupReuseViewMock);

            controller.InsertReferenceAction();
        }

        [Test]
        public void MustCallAppApplyMapping()
        {
            _reuseHandlerMock = MockRepository.GenerateMock<IReuseHandler>();
            _reuseHandlerMock.Expect(x => x.MapReferenceDic(null)).Return(null);

            _setupReuseViewMock.Expect(x => x.GetReuseDefinition()).Return(_reuseHandlerMock); // o view model vai devolver o handler de reuso mockado.
            _setupReuseViewMock.Expect(x => x.IsColorChanges).Return(false);
            _setupReuseViewMock.Expect(x => x.IsRestrictedToSelection).Return(false);

            _appMock.Expect(x => x.GetIndexedReferences(false)); // o app deve receber uma chamada para devolver as suas referencias indexads
            _appMock.Expect(x => x.ApplyMapping(null, false));   // o app deve receber uma chamada para mapear as suas referencias para o gerado pelo handler

            var controller = new AppOfficeControllerBase(_appMock, _addressViewModelMock, _addressFactoryMock,
                                                         _setupReuseViewMock);

            controller.ApplyReferenceReuseAction(); // O controller deve rotear as ações corretas.
        }
    }
}
