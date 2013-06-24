using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppExcel.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace AppExcel
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            new SetUpExportWorkbook().ShowDialog();
        }
    }
}
