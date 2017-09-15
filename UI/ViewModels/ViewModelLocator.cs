using StructureMap;

namespace UI.ViewModels
{
    internal class ViewModelLocator
    {
        private readonly IContainer _container;

        public DeviceCenterViewModel DeviceCenterViewModel => _container.GetInstance<DeviceCenterViewModel>();
        public MainWindowViewModel MainWindowViewModel => _container.GetInstance<MainWindowViewModel>();
        public LaserViewModel LaserViewModel => _container.GetInstance<LaserViewModel>();

        public ViewModelLocator()
        {
            _container = new Container(c =>
            {
                c.AddRegistry(new CommonRegistry());
            });
        }
    }
}
