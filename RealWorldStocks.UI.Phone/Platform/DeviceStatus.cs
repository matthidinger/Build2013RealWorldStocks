using Microsoft.Phone.Info;
using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.UI.Platform
{
    public class DeviceStatus : IDeviceStatus
    {
        public string DeviceName
        {
            get { return Microsoft.Phone.Info.DeviceStatus.DeviceName; }
        }

        public string DeviceManufaturer
        {
            get { return Microsoft.Phone.Info.DeviceStatus.DeviceManufacturer; }
        }

        public long DeviceTotalMemory
        {
            get { return Microsoft.Phone.Info.DeviceStatus.DeviceTotalMemory; }
        }
    }
}