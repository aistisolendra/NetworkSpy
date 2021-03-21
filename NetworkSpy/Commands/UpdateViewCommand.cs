using NetworkSpy.ViewModels;
using System;
using System.Windows.Input;

namespace NetworkSpy.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel _mainViewModel;
        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Home":
                    _mainViewModel.SelectedViewModel = new HomeViewModel();
                    break;
                case "Interface":
                    _mainViewModel.SelectedViewModel = new InterfacesViewModel();
                    break;
            }
        }
    }
}
