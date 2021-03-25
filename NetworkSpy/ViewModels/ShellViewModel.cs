using System;
using System.ComponentModel;
using System.Windows;
using Caliburn.Micro;
using NetworkSpy.Properties;
using NetworkSpy.Services;
using Application = System.Windows.Application;

namespace NetworkSpy.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly NotifyIconService _notifyIconService;
        private readonly HomeViewModel _homeViewModel = new();
        private readonly InterfaceViewModel _interfacesViewModel = new();
        private readonly DevicesViewModel _devicesViewModel = new();

        public ShellViewModel()
        {
            _notifyIconService = new NotifyIconService();

            SetNotifyIconFunctions();
            ActivateItem(_homeViewModel);
        }

        public void SetNotifyIconFunctions()
        {
            _notifyIconService.NotifyIconInstance.DoubleClick += ShowWindow;

            _notifyIconService.AddMenuItem(
                name: Resources.ProjectName,
                image: Resources.MainPage_logo.ToBitmap(),
                eventHandler: ShowWindow);

            _notifyIconService.AddMenuItem(
                name: "Exit app",
                eventHandler: OnAppClose);
        }

        public void LoadMainPage()
        {
            ActivateItem(_homeViewModel);
        }

        public void LoadInterfacePage()
        {
            ActivateItem(_interfacesViewModel);
        }

        public void LoadDevicesPage()
        {
            ActivateItem(_devicesViewModel);
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

        private void OnAppClose(object sender, EventArgs e)
        {
            _notifyIconService.NotifyIconInstance.Dispose();
            Application.Current.Shutdown();
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
