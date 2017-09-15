using Core;
using Core.Model;
using System.Collections.ObjectModel;
using System.Linq;
using UI.Infrastructure;
using UI.ObservableModels;
using UI.Services;

namespace UI.ViewModels
{
    internal class DeviceCenterViewModel : BindableObject
    {
        private readonly IDeviceManager _deviceManager;
        private readonly IDialogService _dialogService;

        private LaserViewModel _laserViewModel;

        private ObservableDevice _selectedDevice;
        public ObservableDevice SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                _selectedDevice = value;

                if (_selectedDevice.Device is ILaser)
                    _laserViewModel.Laser = new ObservableLaser(_selectedDevice.Device as ILaser);

                RaisePropertyChanged();
            }
        }


        private ObservableCollection<ObservableDevice> _devices;
        public ObservableCollection<ObservableDevice> Devices
        {
            get { return _devices; }
            set
            {
                _devices = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand _loadDevicesCommand;
        public RelayCommand LoadDevicesCommand => _loadDevicesCommand ?? (new RelayCommand(LoadDevices));

        public DeviceCenterViewModel(
            IDeviceManager deviceManager,
            IDialogService dialogService,
            LaserViewModel laserViewModel)
        {
            _deviceManager = deviceManager;
            _dialogService = dialogService;

            _laserViewModel = laserViewModel;
        }

        private void LoadDevices()
        {
            var result = _dialogService.ShowDialog(
                "Möchten Sie wirklich die Geräte laden?",
                "Achtung!",
                System.Windows.MessageBoxButton.YesNo);

            if (result == System.Windows.MessageBoxResult.No)
                return;

            var devices = _deviceManager
                .GetDevices()
                .Select(d => new ObservableDevice(d));

            Devices = new ObservableCollection<ObservableDevice>(devices);
        }
    }
}
