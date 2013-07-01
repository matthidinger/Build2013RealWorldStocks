using System;
using System.Threading.Tasks;
using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.UI.Platform
{
    public class Dispatcher : IDispatcher
    {
        public Task InvokeAsync(Action action)
        {
            return App.RootFrame.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => action()).AsTask();
        }
    }
}