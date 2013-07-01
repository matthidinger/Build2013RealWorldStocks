using System;
using System.Collections.Generic;
using System.Linq;

namespace RealWorldStocks.Core
{
    public static class EnumerableExtensions
    {
        public static string ToDataString(this IEnumerable<KeyValuePair<string, string>> nameValueCollection)
        {
            return String.Join("&", nameValueCollection.Select(kvp => String.Format("{0}={1}",
                Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value))).ToArray());
        }
    }
}
