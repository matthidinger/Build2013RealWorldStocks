using RealWorldStocks.Core.Services;
using RealWorldStocks.Core.ViewModels;

namespace RealWorldStocks.UI.ViewModels
{
    public class StockDetailsViewModel : StockDetailsViewModelCore
    {
        public StockDetailsViewModel(IStocksService stocksService) : base(stocksService)
        {
        }
    }
}