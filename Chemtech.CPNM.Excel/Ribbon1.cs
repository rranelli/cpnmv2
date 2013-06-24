using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chemtech.CPNM.AppExcel.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace Chemtech.CPNM.Excel
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            new SetUpExportWorkbook().ShowDialog();
        }
    }
}
