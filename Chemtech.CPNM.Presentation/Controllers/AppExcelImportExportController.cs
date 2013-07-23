using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chemtech.CPNM.BR;

namespace Chemtech.CPNM.Presentation.Controllers
{
    public class AppExcelImportExportController : AppExcelController
    {
        public AppExcelImportExportController(ICPNMApp cpnmApp) : base(cpnmApp) {}
    }
}
