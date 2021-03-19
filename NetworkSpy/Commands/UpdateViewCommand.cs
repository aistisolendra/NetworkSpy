using NetworkSpy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetworkSpy.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel mainViewModel;
        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Home")
                mainViewModel.SelectedViewModel = new HomeViewModel();
            else if (parameter.ToString() == "Connections")
                mainViewModel.SelectedViewModel = new ConnectionsViewModel();
        }
    }
}
