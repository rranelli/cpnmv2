using Chemtech.CPNM.Presentation.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace Chemtech.CPNM.Excel
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            new SetUpSession().ShowDialog();
        }

        private void btnAddRef_Click(object sender, RibbonControlEventArgs e)
        {
            //TODO: implementar o excel heimdall
            new GetReference().ShowDialog();
        }
    }
}
