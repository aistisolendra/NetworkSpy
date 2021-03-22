using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace NetworkSpy.HelperClasses
{
    public static class NetworkInterfaces
    {
        public static List<NetworkInterface> GetNetworkInterfaces()
        {
            return NetworkInterface.GetAllNetworkInterfaces().ToList();
        }

    }
}
