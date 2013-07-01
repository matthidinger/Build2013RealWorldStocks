using System;
using System.IO;
using System.Threading.Tasks;
using RealWorldStocks.Core.Platform;
using Windows.Storage;
using Windows.Storage.Streams;

namespace RealWorldStocks.UI.Platform
{
    public class LocalStorage : ILocalStorage
    {
        public async Task<string> ReadAsync(string fileName)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            using (var stream = await file.OpenReadAsync())
            using (var textReader = new DataReader(stream))
            {
                var textLength = (uint) stream.Size;
                await textReader.LoadAsync(textLength);
                return textReader.ReadString(textLength);
            }
        }

        public async Task SaveAsync(string fileName, string content)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            using (var stream = await file.OpenReadAsync())
            using (var writer = new DataWriter(stream))
            {
                writer.WriteString(content);
                await writer.StoreAsync();
            }
        }

        public async Task DeleteAsync(string fileName)
        {
            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                await file.DeleteAsync();
            }
            catch (FileNotFoundException)
            {
            }
        }
    }
}