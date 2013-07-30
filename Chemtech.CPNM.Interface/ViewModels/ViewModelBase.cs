using System.Windows;

namespace Chemtech.CPNM.Interface.ViewModels
{
    public abstract class ViewModelBase
    {
        protected Window View;
        protected ViewModelBase(Window view)
        {
            View = view;
            View.DataContext = this;
        }

        public void Open()
        {
            View.ShowDialog();
        }

        public void Close()
        {
            View.Close();
        }

        public abstract bool ResultOk();
    }
}