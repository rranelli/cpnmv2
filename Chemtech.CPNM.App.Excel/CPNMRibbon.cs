﻿using Chemtech.CPNM.App.Excel.Application;
using Chemtech.CPNM.BR.DI;
using Chemtech.CPNM.Interface.Controllers;
using Chemtech.CPNM.Interface.ViewModels;
using Chemtech.CPNM.Data.Repositories;
using Microsoft.Office.Tools.Ribbon;

namespace Chemtech.CPNM.App.Excel
{
    public partial class CPNMRibbon
    {
        private AppOfficeControllerBase _officeController;

        private void CPNMRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            //var setupReuseViewModel = DiResolver.IocResolve<ISetupReuseViewModel>(); //TODO: IMPOLEMENTAR
            ISetupReuseViewModel setupReuseViewModel = null;
            var getReferenceViewModel = DiResolver.IocResolve<IGetAddressViewModel>();
            var addressFactory = DiResolver.IocResolve<IAddressFactory>();
            var appExcel = new CPNMAppExcel();

            _officeController = new AppOfficeControllerBase(appExcel, getReferenceViewModel, addressFactory, setupReuseViewModel);
        }

        private void btnInsertReference_Click(object sender, RibbonControlEventArgs e)
        {
            _officeController.InsertReferenceAction();
        }
    }
}