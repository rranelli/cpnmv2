using System;
using System.Windows.Forms;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Presentation.Forms
{
    public partial class SetUpSession : Form
    {
        public SetUpSession()
        {
            InitializeComponent();
            /*
            new GeneralRepository<Project>().
                GetAll().
                ToList().
                ForEach(prj => cmbProjects.Items.Add(prj));*/ 
            // TODO: Refactor this.
        }

        private void btnCommitConfig_Click(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedItem == null || txbUserName.Text == "")
            {
                MessageBox.Show("Você deve configurar um projeto e um nome de usuário");
                return;
            }

            CpnmSession.Project = (Project) cmbProjects.SelectedItem;
            CpnmSession.UserName = txbUserName.Text;
            Close();
        }
    }
}
