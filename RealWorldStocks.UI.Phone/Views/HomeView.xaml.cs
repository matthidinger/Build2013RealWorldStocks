using System.Windows.Navigation;
using RealWorldStocks.UI.ViewModels;

namespace RealWorldStocks.UI.Views
{
    public partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();
            ViewModel = new HomeViewModel();
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


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadAsync();
        }
    }
}