using Core.Model;
using System.Collections.Generic;

namespace Core
{
    public interface IDeviceManager
    {
        IEnumerable<IDevice> GetDevices();
        IEnumerable<TDevice> GetDevices<TDevice>() where TDevice : class, IDevice;
    }
}
