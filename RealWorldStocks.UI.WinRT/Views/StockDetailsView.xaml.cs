using System.Collections.Generic;
using RealWorldStocks.Core.Services;
using RealWorldStocks.UI.ViewModels;

namespace RealWorldStocks.UI.Views
{
    public sealed partial class StockDetailsView
    {
        public StockDetailsView()
        {
            InitializeComponent();
            ViewModel = new StockDetailsViewModel(new YahooStocksService());
        }

        private StockDetailsViewModel _viewModel;
        public StockDetailsViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        protected override async void LoadState(object navigationParameter, Dictionary<string, object> pageState)
        {
            base.LoadState(navigationParameter, pageState);

            var symbol = navigationParameter as string;
            if (symbol != null)
            {
                await ViewModel.LoadAsync(symbol);
            }
        }
    }
}
