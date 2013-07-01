using System.Collections.Generic;
using RealWorldStocks.UI.ViewModels;
using Windows.UI.Xaml.Navigation;

namespace RealWorldStocks.UI.Views
{
    public sealed partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();
            ViewModel = new HomeViewModel();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private HomeViewModel _viewModel;
        public HomeViewModel ViewModel
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
            await ViewModel.LoadAsync();

        }
    }
}
