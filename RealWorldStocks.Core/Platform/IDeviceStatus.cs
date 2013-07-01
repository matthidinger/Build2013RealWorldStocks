namespace RealWorldStocks.Core.Platform
{
    public interface IDeviceStatus
    {
        string DeviceName { get; }
        string DeviceManufaturer { get; }
        long DeviceTotalMemory { get; } 
    }
}