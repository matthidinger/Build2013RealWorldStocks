using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealWorldStocks.Core.Services;

namespace RealWorldStocks.Core.Models
{
    public class WatchList : PersistentCollection<WatchList, StockSnapshot>
    {
        public override string StorageFilename
        {
            get { return "WatchList.txt"; }
        }

        protected override IEnumerable<StockSnapshot> DefaultItems
        {
            get
            {
                yield return new StockSnapshot("MSFT");
                yield return new StockSnapshot("XOM");
                yield return new StockSnapshot("GE");
                yield return new StockSnapshot("BP");
                yield return new StockSnapshot("C");
                yield return new StockSnapshot("WMT");
                yield return new StockSnapshot("T");
                yield return new StockSnapshot("S");
            }
        }


        public StockSnapshot GetBySymbol(string symbol)
        {
            return this.SingleOrDefault(m => m.Symbol == symbol);
        }

        public async Task<IList<StockSnapshot>> RefreshSnapshotsAsync()
        {
            var service = new YahooStocksService();
            var updated = await service.GetSnapshotsAsync(this.Select(m => m.Symbol).ToArray());
            return updated;
        }

        public Task<IList<News>> RefreshNewsAsync()
        {
            var service = new YahooNewsService();
            return service.GetNewsAsync(this.Select(m => m.Symbol).ToArray());
        }
    }
}