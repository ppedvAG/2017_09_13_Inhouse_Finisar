using UI.Infrastructure;
using UI.ObservableModels;

namespace UI.ViewModels
{
    internal class LaserViewModel : BindableObject
    {
        private ObservableLaser _laser;
        public ObservableLaser Laser
        {
            get { return _laser; }
            set
            {
                _laser = value;
                RaisePropertyChanged();
            }
        }
    }
}
