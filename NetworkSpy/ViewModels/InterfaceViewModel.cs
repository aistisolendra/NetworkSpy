using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using NetworkSpy.Models;
using Caliburn.Micro;
using NetworkSpy.HelperClasses;

namespace NetworkSpy.ViewModels
{
    public class InterfaceViewModel : Screen
    {
        public BindableCollection<InterfacesModel> Interfaces { get; set; }
        public InterfaceViewModel()
        {
            Interfaces = new();
            GetInterfaces();
        }

        public void GetInterfaces()
        {
            Interfaces.Clear();

            var interfaces = NetworkInterfaces.GetNetworkInterfaces();

            foreach (var intf in interfaces)
            {
                Interfaces.Add(new InterfacesModel
                {
                    Name = intf.Name,
                    Description = intf.Description,
                    InterfaceType = intf.NetworkInterfaceType.ToString(),
                    IPVersion = GetIPVersion(intf),
                    DNSEnabled = GetDNSEnabled(intf),
                    OpStatus = intf.OperationalStatus.ToString()
                });
            }

            UpdateInterfaceInformation();
        }

        private void UpdateInterfaceInformation()
        {
            int intfCount = Interfaces.Count();
            InterfaceCountText = intfCount > 0 ? $"{intfCount} interfaces found" : "No interfaces found";
        }

        private string GetIPVersion(NetworkInterface intf)
        {
            string returnString = "";

            if (NetworkHelper.SupportsIPv4(intf))
                returnString += "IPv4";

            if (NetworkHelper.SupportsIPv6(intf))
                if (returnString.Length > 0)
                    returnString += " IPv6";
                else
                    returnString += "IPv6";

            return returnString;
        }

        private string GetDNSEnabled(NetworkInterface intf)
        {
            return intf.GetIPProperties().IsDnsEnabled ? "Enabled" : "Disabled";
        }

        private string _interfaceCountText;
        [DefaultValue("No interfaces found")]
        public string InterfaceCountText
        {
            get => _interfaceCountText;
            set
            {
                _interfaceCountText = value;
                NotifyOfPropertyChange(() => InterfaceCountText);
            }
        }
    }
}
