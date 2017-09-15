using System.Windows.Input;
using UI.Infrastructure;

namespace UI.ViewModels
{
    internal class MainWindowViewModel : BindableObject
    {
        private string _welcomeText = "Hallo MVVM";
        public string WelcomeText
        {
            get { return _welcomeText; }
            set
            {
                _welcomeText = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _changeTextCommand;
        public ICommand ChangeTextCommand
        {
            get
            {
                return _changeTextCommand ?? (_changeTextCommand = new RelayCommand(
                    () => WelcomeText = "Neuer Text aus dem VM",
                    () => WelcomeText?.Length < 10));
            }
        }
    }
}
