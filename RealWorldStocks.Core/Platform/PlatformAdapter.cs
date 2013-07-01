namespace RealWorldStocks.Core.Platform
{
    public abstract class PlatformAdapter
    {
        /// <summary>
        /// Provides acess to the current platform adapter
        /// </summary>
        public static PlatformAdapter Current { get; set; }

        public abstract INavigation Navigation { get; }

        public abstract IDispatcher Dispatcher { get; }

        public abstract ILocalStorage LocalStorage { get; }

        public abstract IDeviceStatus Device { get; }

    }
}
