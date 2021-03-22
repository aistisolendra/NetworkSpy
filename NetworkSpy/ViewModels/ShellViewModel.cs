using Caliburn.Micro;

namespace NetworkSpy.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly HomeViewModel _homeViewModel = new HomeViewModel();
        private readonly InterfaceViewModel _interfacesViewModel = new InterfaceViewModel();

        public void LoadMainPage()
        {
            ActivateItem(_homeViewModel);
        }

        public void LoadInterfacePage()
        {
            ActivateItem(_interfacesViewModel);
        }
    }
}
