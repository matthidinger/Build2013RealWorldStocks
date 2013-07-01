using System.Threading.Tasks;

namespace RealWorldStocks.Core
{
    public static class TaskHelper
    {
         public static Task Empty()
         {
             return Task.FromResult(new object());
         }
    }
}