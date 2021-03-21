using NetworkSpy.Models;
using Caliburn.Micro;

namespace NetworkSpy.ViewModels
{
    public class InterfacesViewModel : BaseViewModel
    {
        public BindableCollection<InterfacesModel> Interfaces { get; set; }
        public InterfacesViewModel()
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
