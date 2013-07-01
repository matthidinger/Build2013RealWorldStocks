using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.UI.Platform
{
    public class DeviceStatus : IDeviceStatus
    {
        public string DeviceName
        {
            get
            {
                var i = new Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
                return i.SystemProductName;
            }
        }

        public string DeviceManufaturer
        {
            get
            {
                var i = new Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
                return i.SystemManufacturer;
            }
        }

        public long DeviceTotalMemory
        {
            get
            {
                // TODO: Can I get this info?
                return -1;
            }
        }
    }
}