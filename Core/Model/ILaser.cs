namespace Core.Model
{
    public interface ILaser : IDevice
    {
        bool IsOn { get; set; }

        void SetPower(double power);
    }
}