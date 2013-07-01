using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RealWorldStocks.Core;
using RealWorldStocks.Core.Models;
using RealWorldStocks.Core.ViewModels;
using RealWorldStocks.UI.Models;

namespace RealWorldStocks.UI.ViewModels
{
    public class HomeViewModel : HomeViewModelCore
    {
        public ObservableCollection<Group> Groups { get; private set; }

        public HomeViewModel()
        {
            Groups = new ObservableCollection<Group>();
        }

        public override async Task LoadAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await WatchList.InitializeAsync();
            
            WatchListItems.Repopulate(await WatchList.Current.RefreshSnapshotsAsync());
            News.Repopulate(await WatchList.Current.RefreshNewsAsync());

            Groups.Repopulate(new Group[]
            {
                new Group<StockSnapshot>("Watch List")
                {
                    Items = WatchListItems,
                },
                new Group<News>("News")
                {
                    Items = News
                },
            });

            IsBusy = false;
        }
    }
}