using System.Collections.Generic;
using System.Net.NetworkInformation;
using Caliburn.Micro;
using NetworkSpy.Models;

namespace NetworkSpy.Services
{
    public class DevicesFinder
    {
        private readonly string[] _ipBases;
        public DevicesFinder(string[] ipBases)
        {
            _ipBases = ipBases;
        }

        public BindableCollection<DeviceModel> FindDevices()
        {
            BindableCollection<DeviceModel> deviceModels = new();

            foreach (string subnet in _ipBases)
            {
                deviceModels.AddRange(FindDevicesOnSubnet(subnet));
            }

            return deviceModels;
        }

        private static IEnumerable<DeviceModel> FindDevicesOnSubnet(string subnet)
        {
            BindableCollection<DeviceModel> devices = new();

            for (int i = 1; i < 255; ++i)
            {
                string ip = $"{subnet}{i}";
                var device = FindDeviceOnIP(ip);

                if (device != null) devices.Add(device);
            }

            return devices;
        }

        private static DeviceModel FindDeviceOnIP(string ip)
        {
            var ping = new Ping();
            var reply = ping.Send(ip);

            return IsPingSuccessful(reply) ? new DeviceModel(ip) : null;
        }

        private static bool IsPingSuccessful(PingReply rep)
        {
            return rep != null && rep.Status == IPStatus.Success;
        }
    }
}
