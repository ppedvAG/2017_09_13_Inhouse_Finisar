using Hardware.Simulate;
using UI.Services;

namespace UI.ViewModels
{
    internal class ViewModelLocator
    {
        private DeviceCenterViewModel _deviceCenterViewModel;
        public DeviceCenterViewModel DeviceCenterViewModel => _deviceCenterViewModel;

        private MainWindowViewModel _mainWindowViewModel;
        public MainWindowViewModel MainWindowViewModel => _mainWindowViewModel;

        private LaserViewModel _laserViewModel;
        public LaserViewModel LaserViewModel => _laserViewModel;

        public ViewModelLocator()
        {
            var deviceManager = new DeviceManager();
            _laserViewModel = new LaserViewModel();
            _deviceCenterViewModel = new DeviceCenterViewModel(
                deviceManager, 
                new DialogService(),
                _laserViewModel);

            _mainWindowViewModel = new MainWindowViewModel();
        }
    }
}
