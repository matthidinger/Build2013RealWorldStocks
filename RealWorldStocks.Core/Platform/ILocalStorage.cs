using System.Threading.Tasks;

namespace RealWorldStocks.Core.Platform
{
    public interface ILocalStorage
    {
        Task<string> ReadAsync(string fileName);
        Task SaveAsync(string fileName, string content);
        Task DeleteAsync(string fileName);
    }
}