using System;
using System.Globalization;
#if WINDOWS_PHONE
using System.Windows.Data;
#endif
#if NETFX_CORE
using Windows.UI.Xaml.Data;
#endif

namespace RealWorldStocks.UI.Converters
{   
    public abstract class ConverterBase : IValueConverter
    {
        public abstract object ConvertCore(object value, Type targetType, object parameter);
        public abstract object ConvertBackCore(object value, Type targetType, object parameter);

#if NETFX_CORE

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ConvertCore(value, targetType, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ConvertBackCore(value, targetType, parameter);
        }

#else
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertCore(value, targetType, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBackCore(value, targetType, parameter);
        }

#endif

    }
}