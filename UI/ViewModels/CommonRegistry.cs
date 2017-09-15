using Core;
using Hardware.Simulate;
using StructureMap;
using UI.Services;

namespace UI.ViewModels
{
    internal class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            For<IDeviceManager>().Use<DeviceManager>().Singleton();

            For<IDialogService>().Use<DialogService>().Singleton();

            ForConcreteType<LaserViewModel>().Configure.Singleton();
        }
    }
}
