using System.Collections.Generic;
using System.Threading.Tasks;
using RealWorldStocks.Core.Models;

namespace RealWorldStocks.Core.Services
{
    public interface IStocksService
    {
        Task<IList<StockSnapshot>> GetSnapshotsAsync(string[] symbols);
    }
}