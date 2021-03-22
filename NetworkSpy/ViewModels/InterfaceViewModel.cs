using NetworkSpy.Models;
using Caliburn.Micro;

namespace NetworkSpy.ViewModels
{
    public class InterfaceViewModel : Screen
    {
        public BindableCollection<InterfacesModel> Interfaces { get; set; }
        public InterfaceViewModel()
        {
            Interfaces = new BindableCollection<InterfacesModel>()
            {
                new InterfacesModel()
                {
                    DNSEnabled = "test",
                    InterfaceType = "test",
                    IPVersion = "test",
                    OpStatus = "test"
                }
            };
        }
    }
}
