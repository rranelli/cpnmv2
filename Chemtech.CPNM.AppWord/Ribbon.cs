// Ribbon.cs
// Projeto: Chemtech.CPNM.AppWord
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 16/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using Chemtech.CPNM.AppWord.Application;
using Microsoft.Office.Tools.Ribbon;

namespace Chemtech.CPNM.AppWord
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnAddRef_Click(object sender, RibbonControlEventArgs e)
        {
            new WordHeimdall().InsertReference();
        }

        private void btnFetchAll_Click(object sender, RibbonControlEventArgs e)
        {
            new WordHeimdall().FetchAllDocVars();
        }

        private void btnRefReuse_Click(object sender, RibbonControlEventArgs e)
        {
            new WordHeimdall().ReuseReferences();
        }
    }
}