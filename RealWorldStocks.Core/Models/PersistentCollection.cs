using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using RealWorldStocks.Core.Logging;
using RealWorldStocks.Core.Platform;

namespace RealWorldStocks.Core.Models
{
    public abstract class PersistentCollection<TCollection, TItem> : ObservableCollection<TItem>
        where TCollection : PersistentCollection<TCollection, TItem>, new()
        where TItem : class
    {
        public abstract string StorageFilename { get; }

        public static async Task InitializeAsync()
        {
            if (Current == null)
            {
                Current = new TCollection();
                await Current.LoadFromCacheAsync();
            }
        }

        public static TCollection Current { get; private set; }

        protected abstract IEnumerable<TItem> DefaultItems { get; }

        public async Task LoadFromCacheAsync()
        {
            var json = await PlatformAdapter.Current.LocalStorage.ReadAsync(StorageFilename);
            if (string.IsNullOrEmpty(json))
            {
                foreach (var item in DefaultItems)
                {
                    Add(item);
                }
            }
            else
            {
                try
                {
                    var cached = SerializationHelper.Deserialize<ObservableCollection<TItem>>(json);
                    if (cached == null || cached.Count == 0)
                        throw new Exception();

                    foreach (var item in cached)
                    {
                        Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log("ERROR: Unable to parse persistent storage");
#if !DEBUG
                    PlatformAdapter.Current.LocalStorage.DeleteAsync(StorageFilename);
#endif
                }
            }
        }

        public async Task PersistDataAsync()
        {
            try
            {
                var json = SerializationHelper.Serialize(this);
                await PlatformAdapter.Current.LocalStorage.SaveAsync(StorageFilename, json);
            }
            catch (Exception)
            {
                Debug.WriteLine(string.Format("Unable to properly serialize to {0}!", StorageFilename));
            }
        }

        public void Delete()
        {
            Clear();

            PlatformAdapter.Current.LocalStorage.DeleteAsync(StorageFilename);
        }
    }
}