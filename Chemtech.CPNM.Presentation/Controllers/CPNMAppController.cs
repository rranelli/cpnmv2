using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chemtech.CPNM.BR;

namespace Chemtech.CPNM.Presentation.Controllers
{
    public abstract class CPNMAppController
    {
        private ICPNMApp _cpnmApp;

        protected CPNMAppController(ICPNMApp cpnmApp)
        {
            _cpnmApp = cpnmApp;
        }


    }
}
