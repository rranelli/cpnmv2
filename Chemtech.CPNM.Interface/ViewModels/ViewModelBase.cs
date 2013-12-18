using System.ComponentModel;
using System.Windows;
using Chemtech.CPNM.Interface.Views;

namespace Chemtech.CPNM.Interface.ViewModels
{
    public interface IViewModelBase {
        void Open();
        void Close();
        bool ResultOk();
    }

    public abstract class ViewModelBase : IViewModelBase
    {
        protected Window View;
        protected ViewModelBase(Window view)
        {
            View = view;
            View.DataContext = this;
        }

        public void Open()
        {
            View.Show();
        }

        public void Close()
        {
            View.Close();
        }

        public abstract bool ResultOk();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}