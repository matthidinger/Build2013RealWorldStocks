using RealWorldStocks.Core.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RealWorldStocks.UI.Models
{
    public class HomeViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NewsItemTemplate { get; set; }
        public DataTemplate SnapshotItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is News)
                return NewsItemTemplate;

            if (item is StockSnapshot)
                return SnapshotItemTemplate;

            return base.SelectTemplateCore(item, container);
        }
    }
}