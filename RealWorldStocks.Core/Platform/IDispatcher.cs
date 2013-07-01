using System;
using System.Threading.Tasks;

namespace RealWorldStocks.Core.Platform
{
    public interface IDispatcher
    {
        Task InvokeAsync(Action action);
    }
}