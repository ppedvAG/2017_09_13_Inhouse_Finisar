using System;

namespace Core.Model
{
    public interface IDevice
    {
        event Action ConnectionOpend;
        event Action ConnectionClosed;

        string Name { get; set; }
        bool IsConnected { get; set; }

        void Open();
        void Close();
    }
}
