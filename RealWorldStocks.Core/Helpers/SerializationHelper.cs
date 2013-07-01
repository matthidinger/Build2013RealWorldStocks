using Newtonsoft.Json;

namespace RealWorldStocks.Core
{
    public static class SerializationHelper
    {
        public static T Deserialize<T>(string serialized)
        {
            if (string.IsNullOrEmpty(serialized))
                return default(T);

            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}