using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using NetworkSpy.Models;

namespace NetworkSpy.Services
{
    public static class NetworkInterfacesHelper
    {
        public static List<NetworkInterface> GetNetworkInterfaces()
        {
            return NetworkInterface.GetAllNetworkInterfaces().ToList();
        }

        public static InterfacesModel CreateInterfaceModel(NetworkInterface intf)
        {
            return new()
            {
                Name = intf.Name,
                Description = intf.Description,
                InterfaceType = intf.NetworkInterfaceType.ToString(),
                IPVersion = GetIPVersions(intf),
                DNSEnabled = GetDNSEnabled(intf),
                OpStatus = intf.OperationalStatus.ToString()
            };
        }

        public static string GetIPVersions(NetworkInterface intf)
        {
            string returnString = "";

            if (NetworkHelper.SupportsIPv4(intf))
                returnString += "IPv4";

            if (!NetworkHelper.SupportsIPv6(intf)) return returnString;
            return returnString + (returnString.Length > 0 ? " IPv6" : "IPv6");
        }

        public static string GetDNSEnabled(NetworkInterface intf)
        {
            return intf.GetIPProperties().IsDnsEnabled ? "Enabled" : "Disabled";
        }
    }
}
