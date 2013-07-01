using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using RealWorldStocks.Core.Models;

namespace RealWorldStocks.Core.Services
{
    public class YahooNewsService
    {
        public async Task<IList<News>> GetNewsAsync(string[] symbols)
        {
            var url = string.Format("http://feeds.finance.yahoo.com/rss/2.0/headline?s={0}&region=US&lang=en-US", string.Join(",", symbols));

            var httpClient = new HttpClient();            
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }


            var str = await response.Content.ReadAsStringAsync();
            var doc = XDocument.Parse(str);

            var model = doc.Descendants("item")
                .Select(item =>
                        new News
                        {
                            Title = item.Element("title").Value,
                            ArticleDate = DateTime.Parse(item.Element("pubDate").Value),
                            Url = item.Element("link").Value,
                        });

            return model.ToList();
        }
    }
}