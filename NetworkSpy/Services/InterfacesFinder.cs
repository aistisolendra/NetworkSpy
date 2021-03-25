using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Caliburn.Micro;
using NetworkSpy.Models;

namespace NetworkSpy.Services
{
    public class InterfacesFinder
    {
        private readonly List<NetworkInterface> _allInterfaces;
        public InterfacesFinder()
        {
            _allInterfaces = NetworkInterface.GetAllNetworkInterfaces().ToList();
        }

        public BindableCollection<InterfacesModel> FindInterfaces()
        {
            BindableCollection<InterfacesModel> interfacesModels = new();

            foreach (var @interface in _allInterfaces)
            {
                interfacesModels.Add(new InterfacesModel(@interface, GetIPVersions(@interface)));
            }

            return interfacesModels;
        }

        public string GetIPVersions(NetworkInterface @interface)
        {
            var ipVersions = new List<string>();

            if (@interface.Supports(NetworkInterfaceComponent.IPv4))
                ipVersions.Add(NetworkInterfaceComponent.IPv4.ToString());

            if (@interface.Supports(NetworkInterfaceComponent.IPv6))
                ipVersions.Add(NetworkInterfaceComponent.IPv6.ToString());

            return string.Join(" ", ipVersions);
        }
    }
}