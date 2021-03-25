using System.Net.NetworkInformation;

namespace NetworkSpy.Models
{
    public class InterfacesModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string InterfaceType { get; set; }
        public string OpStatus { get; set; }
        public string DNSEnabled { get; set; }
        public string IPVersion { get; set; }

        public InterfacesModel(NetworkInterface @interface, string ipVersion)
        {
            Name = @interface.Name;
            Description = @interface.Description;
            Name = @interface.Name;
            Description = @interface.Description;
            InterfaceType = @interface.NetworkInterfaceType.ToString();
            IPVersion = ipVersion;
            DNSEnabled = @interface.GetIPProperties().IsDnsEnabled.ToString();
            OpStatus = @interface.OperationalStatus.ToString();
        }
    }
}
