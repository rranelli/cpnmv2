// ThisAddIn.cs
// Projeto: Chemtech.CPNM.AppWord
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 16/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using Chemtech.CPNM.Tests.UnitTests;
using Office = Microsoft.Office.Core;

namespace Chemtech.CPNM.AppWord
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            //TODO: Codigo para tests apenas. REMOVER.
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
            Shutdown += ThisAddIn_Shutdown;
        }

        #endregion
    }
}