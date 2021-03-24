using System.ComponentModel;
using System.Linq;
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

            var interfaces = NetworkInterfacesHelper.GetNetworkInterfaces();
            interfaces.ForEach(i => Interfaces
                      .Add(NetworkInterfacesHelper.CreateInterfaceModel(i)));

            UpdateInterfaceInformation();
        }

        private void UpdateInterfaceInformation()
        {
            int intfCount = Interfaces.Count();
            InterfaceCountText = intfCount > 0 ? $"{intfCount} interfaces found" : "No interfaces found";
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
