using Core.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Hardware.Simulate.Model
{
    public class Laser : ILaser
    {
        private double _power;

        private bool _isOn;
        public bool IsOn
        {
            get { return _isOn; }
            set
            {
                if(value && !_isOn)
                    Task.Run(() => Console.Beep(
                        frequency: (int)_power, 
                        duration: 1500));
                
                _isOn = value;
            }
        }
        public string Name { get; set; }
        public bool IsConnected { get; set; }

        public event Action ConnectionOpend;
        public event Action ConnectionClosed;

        public void Close()
        {
            IsConnected = false;
            ConnectionClosed?.Invoke();
            Debug.WriteLine($"Laser {Name}: Connection closed.");
        }
        public void Open()
        {
            IsConnected = true;
            ConnectionOpend?.Invoke();
            Debug.WriteLine($"Laser {Name}: Connection opend.");
        }
        public void SetPower(double power)
        {
            _power = power;
            Debug.WriteLine($"Laser {Name}: Power set to {power}dBm.");
        }
    }
}
