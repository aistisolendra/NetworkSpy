using System.Net.NetworkInformation;

namespace NetworkSpy.HelperClasses
{
    public static class NetworkHelper
    {
        public static bool SupportsIPv4(NetworkInterface adapter)
        {
            return adapter.Supports(NetworkInterfaceComponent.IPv4);
        }

        public static bool SupportsIPv6(NetworkInterface adapter)
        {
            return adapter.Supports(NetworkInterfaceComponent.IPv6);
        }
    }
}
