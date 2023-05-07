using Newtonsoft.Json;

namespace Serializer
{
    public static class Serializer<T>
    {
        public static async Task<string> SerializeJSON(T obj)
        {
            return await Task.Run(() =>
            {
                string json = JsonConvert.SerializeObject(obj);
                return json;
            });
        }

        public static async Task<T?> DeserializeJSON(string json)
        {
            return await Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<T>(json);
            });
        }
    }
}