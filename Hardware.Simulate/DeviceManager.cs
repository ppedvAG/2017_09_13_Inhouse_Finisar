using System.Collections.Generic;
using Core;
using Core.Model;
using Hardware.Simulate.Model;
using System.Linq;

namespace Hardware.Simulate
{
    public class DeviceManager : IDeviceManager
    {
        private IEnumerable<IDevice> _devices => new List<IDevice>
        {
            new Laser { Name = "Laser_81A49a", IsConnected = true },
            new Laser { Name = "Laser_81A49b", IsConnected = true },
            new Laser { Name = "Laser_81A49c", IsConnected = true },
            new Laser { Name = "Laser_81A49d", IsConnected = false },
            new Laser { Name = "Laser_81A49e", IsConnected = true },

            new Smu { Name = "Smu_H7XO9", IsConnected = false },
            new Smu { Name = "Smu_H7XP2", IsConnected = true },
            new Smu { Name = "Smu_H7XG4", IsConnected = false },
            new Smu { Name = "Smu_H7XI7", IsConnected = true },
            new Smu { Name = "Smu_H7XL1", IsConnected = false },
        };

        public IEnumerable<IDevice> GetDevices() => _devices;
        public IEnumerable<TDevice> GetDevices<TDevice>() where TDevice : class, IDevice => GetDevices().OfType<TDevice>();
    }
}
