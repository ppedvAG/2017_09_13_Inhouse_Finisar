namespace Core.Model
{
    public interface ISmu : IDevice
    {
        void SetVoltage(double v);
        double Measure();
    }
}