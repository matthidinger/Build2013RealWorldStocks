using System.IO;
using System.Text;

namespace RealWorldStocks.Core
{
    public static class StreamExtensions
    {
        public static void WriteString(this Stream stream, string s)
        {
            byte[] data = Encoding.UTF8.GetBytes(s);
            stream.Write(data, 0, data.Length);
        }
    }
}
