using Core.Model;
using System.Windows.Input;
using UI.Infrastructure;
using System;

namespace UI.ObservableModels
{
    internal class ObservableDevice : BindableObject, IDevice
    {
        public IDevice Device { get; }

        public ObservableDevice(IDevice device)
        {
            Device = device;
            Device.ConnectionOpend += () => RaisePropertyChanged(nameof(IsConnected));
            Device.ConnectionClosed += () => RaisePropertyChanged(nameof(IsConnected));
        }

        public virtual string Name
        {
            get { return Device.Name; }
            set
            {
                Device.Name = value;
                RaisePropertyChanged();
            }
        }
        public virtual bool IsConnected
        {
            get { return Device.IsConnected; }
            set
            {
                Device.IsConnected = value;
                RaisePropertyChanged();
            }
        }

        public virtual void Close() => Device.Close();
        public virtual void Open() => Device.Open();

        private ICommand _openCommand;
        public virtual ICommand OpenCommand => _openCommand ?? (_openCommand = new RelayCommand(
            execute: Open,
            canExecute: () => !IsConnected));

        private ICommand _closeCommand;
        public virtual ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand(
            execute: Close,
            canExecute: () => IsConnected));

        public event Action ConnectionOpend
        {
            add { Device.ConnectionOpend += value; }
            remove { Device.ConnectionOpend -= value; }
        }
        public event Action ConnectionClosed
        {
            add { Device.ConnectionClosed += value; }
            remove { Device.ConnectionClosed -= value; }
        }
    }
}
