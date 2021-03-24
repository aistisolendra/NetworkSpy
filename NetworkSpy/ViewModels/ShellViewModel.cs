using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Caliburn.Micro;
using NetworkSpy.HelperClasses;
using NetworkSpy.Properties;
using Application = System.Windows.Application;

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
            HandleNotifyIconMenuEvents();

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

        public void OnClose(CancelEventArgs e)
        {
            MainWindowVisibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void ShowWindow(object sender, EventArgs e)
        {
            MainWindowVisibility = Visibility.Visible;
        }

        private void CloseApp(object sender, EventArgs e)
        {
            _notifyIcon.Dispose();
            Application.Current.Shutdown();
        }

        private void HandleNotifyIconMenuEvents()
        {
            NotifyIconHelper.AddMenuItem(_notifyIcon,
                name: Resources.ProjectName,
                image: Resources.MainPage_logo.ToBitmap(),
                eventHandler: ShowWindow);

            NotifyIconHelper.AddMenuItem(_notifyIcon,
                name: "Exit app",
                eventHandler: CloseApp);
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
