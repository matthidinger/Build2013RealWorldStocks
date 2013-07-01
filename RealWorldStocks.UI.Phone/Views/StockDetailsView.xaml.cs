using System.Windows.Navigation;
using RealWorldStocks.Core.Services;
using RealWorldStocks.UI.ViewModels;

namespace RealWorldStocks.UI.Views
{
    public partial class StockDetailsView
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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var symbol = NavigationContext.QueryString["symbol"];
            if (symbol != null)
            {
                await ViewModel.LoadAsync(symbol);
            }
        }
    }
}