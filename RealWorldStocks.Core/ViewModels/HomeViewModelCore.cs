using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RealWorldStocks.Core.Models;

namespace RealWorldStocks.Core.ViewModels
{
    public abstract class HomeViewModelCore : NotifyObject
    {
        protected HomeViewModelCore()
        {
            WatchListItems = new ObservableCollection<StockSnapshot>();
            News = new ObservableCollection<News>();
        }

        public ObservableCollection<StockSnapshot> WatchListItems { get; private set; }

        public ObservableCollection<News> News { get; private set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy); 
            }
        }

        public abstract Task LoadAsync();
    }
}