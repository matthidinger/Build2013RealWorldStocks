using System;
using System.Collections.Generic;

namespace RealWorldStocks.Core
{
    public static class CollectionHelper
    {
        public static void Repopulate<T>(this ICollection<T> source, IEnumerable<T> newItemsSource)
        {
            if (source == null)
                throw new InvalidOperationException("Attempted to repopulate a null source");

            source.Clear();
            foreach (var item in newItemsSource)
            {
                source.Add(item);
            }
        } 
    }
}