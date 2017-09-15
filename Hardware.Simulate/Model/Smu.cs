using Core.Model;
using System;
using System.Diagnostics;

namespace Hardware.Simulate.Model
{
    public class Smu : ISmu
    {
        private Random _valueGenerator = new Random();

        public string Name { get; set; }
        public bool IsConnected { get; set; }

        public event Action ConnectionOpend;
        public event Action ConnectionClosed;

        public void Close()
        {
            IsConnected = false;
            ConnectionClosed?.Invoke();
            Debug.WriteLine($"Smu {Name}: Connection closed.");
        }
        public double Measure() => _valueGenerator.NextDouble() * 500;
        public void Open()
        {
            IsConnected = true;
            ConnectionOpend?.Invoke();
            Debug.WriteLine($"Smu {Name}: Connection opend.");
        }
        public void SetVoltage(double v) => Debug.WriteLine($"Smu {Name}: Voltage set to {v}V.");
    }
}
