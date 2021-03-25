using Caliburn.Micro;
using NetworkSpy.Models;
using NetworkSpy.Services;

namespace NetworkSpy.ViewModels
{
    public class DevicesViewModel : Screen
    {
        public BindableCollection<DeviceModel> Devices { get; set; }
        private readonly DevicesFinder _devicesFinder;
        public DevicesViewModel()
        {
            _devicesFinder = new DevicesFinder(new[] { "192.168.0.", "192.168.1." });
            Devices = new BindableCollection<DeviceModel>();

            GetAllDevices();
        }

        public void GetAllDevices()
        {
            Devices.Clear();
            Devices = _devicesFinder.FindDevices();
        }
    }

}
