using Core.Model;
using System.Windows.Input;
using UI.Infrastructure;

namespace UI.ObservableModels
{
    internal class ObservableLaser : ObservableDevice, ILaser
    {
        protected ILaser Laser { get; }

        public ObservableLaser(ILaser device) : base(device)
        {
            Laser = device;
        }

        public bool IsOn
        {
            get { return Laser.IsOn; }
            set
            {
                Laser.IsOn = value;
                RaisePropertyChanged();
            }
        }

        public void SetPower(double power) => Laser.SetPower(power);

        private ICommand _setPowerCommand;
        public ICommand SetPowerCommand => _setPowerCommand ?? (_setPowerCommand = new RelayCommand<double>(SetPower));
    }
}
