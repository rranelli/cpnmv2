using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chemtech.CPNM.BR.ReuseLogic;
using Chemtech.CPNM.Model.Domain;

namespace Chemtech.CPNM.Interface.Views
{
    /// <summary>
    /// Interaction logic for SetupReuseView.xaml
    /// </summary>
    public partial class SetupReuseView : Window
    {
        public SetupReuseView()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            base.Show();
        }
    }
}
