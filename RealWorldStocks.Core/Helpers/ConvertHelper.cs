using System;

namespace RealWorldStocks.Core
{
    public static class ConvertHelper
    {
        public static T ConvertTo<T>(this string value)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}