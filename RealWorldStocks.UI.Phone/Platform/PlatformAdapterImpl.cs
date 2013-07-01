using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.UI.Platform
{
    public class PlatformAdapterImpl : PlatformAdapter
    {
        private readonly ILocalStorage _fileStorage = new LocalStorage();
        private readonly INavigation _navigation = new Navigation();
        private readonly IDispatcher _dispatcher = new Dispatcher();
        private readonly IDeviceStatus _deviceStatus = new DeviceStatus();

        public override INavigation Navigation
        {
            get { return _navigation; }
        }

        public override IDispatcher Dispatcher
        {
            get { return _dispatcher; }
        }

        public override ILocalStorage LocalStorage
        {
            get { return _fileStorage; }
        }

        public override IDeviceStatus Device
        {
            get { return _deviceStatus;  }
        }
    }
}
