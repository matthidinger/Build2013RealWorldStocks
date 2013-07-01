using System.Threading.Tasks;
using RealWorldStocks.Core;
using RealWorldStocks.Core.Models;
using RealWorldStocks.Core.ViewModels;

namespace RealWorldStocks.UI.ViewModels
{
    public class HomeViewModel : HomeViewModelCore
    {
        public override async Task LoadAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await WatchList.InitializeAsync();

            WatchListItems.Repopulate(await WatchList.Current.RefreshSnapshotsAsync());
            News.Repopulate(await WatchList.Current.RefreshNewsAsync());
            IsBusy = false;
        }
    }
}