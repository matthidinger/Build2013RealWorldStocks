using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RealWorldStocks.Core.Models;

namespace RealWorldStocks.Core.Services
{
    public class YahooStocksService : IStocksService
    {
        public async Task<IList<StockSnapshot>> GetSnapshotsAsync(string[] symbols)
        {
            var url = string.Format("http://finance.yahoo.com/d/quotes.csv?s={0}&f=snol1vpc1p2ghyra2j1abe8", string.Join("+", symbols));

            var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var csv = await response.Content.ReadAsStringAsync();
            csv = csv.TrimEnd('\r', '\n');

            var snapshots = from line in csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                        let columns = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").Select(s => s.Replace("\"", "")).ToList()
                        select new StockSnapshot
                        {
                            Symbol = columns[0],
                            Company = columns[1],
                            OpeningPrice = columns[2].ConvertTo<decimal>(),
                            LastPrice = columns[3].ConvertTo<decimal>(),
                            Volume = columns[4].ConvertTo<int>(),
                            PreviousClose = columns[5].ConvertTo<decimal>(),
                            DaysChange = columns[6].ConvertTo<decimal>(),
                            DaysChangePercentFormatted = columns[7],
                            LowPrice = columns[8].ConvertTo<decimal>(),
                            HighPrice = columns[9].ConvertTo<decimal>(),
                            DivAndYield = columns[10],
                            PERatio = columns[11].ConvertTo<decimal>(),
                            AverageVolume = columns[12].ConvertTo<int>(),
                            MarketCap = columns[13],
                            Ask = columns[14],
                            Bid = columns[15],
                            OneYearEstimate = columns[16].ConvertTo<decimal>(),
                        };

            return snapshots.ToList();
        }
    }
}