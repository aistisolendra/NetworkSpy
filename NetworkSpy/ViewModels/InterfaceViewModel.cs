using System.ComponentModel;
using System.Linq;
using NetworkSpy.Models;
using Caliburn.Micro;
using NetworkSpy.Services;

namespace NetworkSpy.ViewModels
{
    public class InterfaceViewModel : Screen
    {
        private readonly InterfacesFinder _interfacesFinder;
        public BindableCollection<InterfacesModel> Interfaces { get; set; }
        public InterfaceViewModel()
        {
            _interfacesFinder = new InterfacesFinder();
            Interfaces = new BindableCollection<InterfacesModel>();

            GetAllInterfaces();
        }

        public void GetAllInterfaces()
        {
            Interfaces.Clear();
            Interfaces = _interfacesFinder.FindInterfaces();

            UpdatePageText();
        }

        private void UpdatePageText()
        {
            int interfacesCount = Interfaces.Count();
            InterfaceCountText = interfacesCount > 0 ? $"{interfacesCount} interfaces found" : "No interfaces found";
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
