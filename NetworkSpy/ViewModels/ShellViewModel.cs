using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Caliburn.Micro;
using NetworkSpy.HelperClasses;

namespace NetworkSpy.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly HomeViewModel _homeViewModel = new();
        private readonly InterfaceViewModel _interfacesViewModel = new();

        public ShellViewModel()
        {
            _notifyIcon = NotifyIconHelper.CreateNotifyIcon();

            _notifyIcon.DoubleClick += ShowWindow;

            ActivateItem(_homeViewModel);
        }

        public void LoadMainPage()
        {
            ActivateItem(_homeViewModel);
        }

        public void LoadInterfacePage()
        {
            ActivateItem(_interfacesViewModel);
        }

        private void ShowWindow(object sender, EventArgs e)
        {
            MainWindowVisibility = Visibility.Visible;
        }

        public void OnClose(CancelEventArgs e)
        {
            MainWindowVisibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private Visibility _mainWindowVisibility;

        [DefaultValue(true)]
        public Visibility MainWindowVisibility
        {
            get => _mainWindowVisibility;
            set
            {
                _mainWindowVisibility = value;
                NotifyOfPropertyChange(() => MainWindowVisibility);
            }
        }
    }
}
