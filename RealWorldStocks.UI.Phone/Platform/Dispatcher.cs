using System;
using System.Threading.Tasks;
using System.Windows;
using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.UI.Platform
{
    public class Dispatcher : IDispatcher
    {
        public Task InvokeAsync(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                try
                {
                    action();
                    tcs.SetResult(null);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }

            });
            return tcs.Task;
        }
    }
}