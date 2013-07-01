using System.Threading.Tasks;
using RealWorldStocks.Core.Models;
using RealWorldStocks.Core.Services;

namespace RealWorldStocks.Core.ViewModels
{
    public class StockDetailsViewModelCore : NotifyObject
    {
        private readonly IStocksService _stocksService;

        public StockDetailsViewModelCore(IStocksService stocksService)
        {
            _stocksService = stocksService;
        }

        public async Task LoadAsync(string symbol)
        {
            Snapshot = WatchList.Current.GetBySymbol(symbol);

            var result = await _stocksService.GetSnapshotsAsync(new[] {symbol});
            if (result != null)
            {
                Snapshot = result[0];
            }
        }

        private StockSnapshot _snapshot;
        public StockSnapshot Snapshot
        {
            get { return _snapshot; }
            set
            {
                _snapshot = value;
                NotifyOfPropertyChange(() => Snapshot);
            }
        }
    }
}