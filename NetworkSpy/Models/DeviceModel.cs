using System.Net;

namespace NetworkSpy.Models
{
    public class DeviceModel
    {
        public string ComputerName { get; }
        public string MACAddress { get; }
        public string AssignedIP { get; }

        public DeviceModel(string ipAddress)
        {
            AssignedIP = ipAddress;
            ComputerName = Dns.GetHostEntry(ipAddress).HostName;
            MACAddress = Dns.GetHostEntry(ipAddress).AddressList[0].ToString();
        }
    }
}
