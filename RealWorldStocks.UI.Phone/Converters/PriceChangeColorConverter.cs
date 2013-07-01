using System;
#if WINDOWS_PHONE
using System.Windows.Media;
#endif
#if NETFX_CORE
using Windows.UI;
using Windows.UI.Xaml.Media;
#endif

namespace RealWorldStocks.UI.Converters
{
    public class PriceChangeColorConverter : ConverterBase
    {
        public override object ConvertCore(object value, Type targetType, object parameter)
        {
            var priceChange = value as decimal?;

            if (priceChange != null && priceChange < 0)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
            {
                return new SolidColorBrush(Colors.Green);
            }
        }

        public override object ConvertBackCore(object value, Type targetType, object parameter)
        {
            throw new NotImplementedException();
        }
    }
}