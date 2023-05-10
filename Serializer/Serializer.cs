#pragma warning disable SYSLIB0011

using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;


namespace Serializer
{
    public static class Serializer
    {
        public static async Task SerializeJSONAsync<T>(T obj, string fileName)
        {
            await Task.Run(() =>
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    var json = JsonConvert.SerializeObject(obj);
                    fs.Write(Encoding.ASCII.GetBytes(json));
                }
            });
        }

        public static async Task<T?> DeSerializeJSONAsync<T>(string fileName)
        {
            return await Task.Run(() =>
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string textFromFile = Encoding.Default.GetString(buffer);

                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
                }
            });
        }

        public static async Task SerializeXMLAsync<T>(T obj, string fileName)
        {
            await Task.Run(() =>
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, obj);
                }
            });
        }

        public static async Task<T?> DeSerializeXMLAsync<T>(string fileName)
        {
            return await Task.Run(() =>
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    return (T)xmlSerializer.Deserialize(fs);
                }
            });
        }

        public static async Task SerializeBinAsync<T>(T obj, string fileName)
        {
            await Task.Run(() =>
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(fs, obj);
                }
            });
        }

        public static async Task<T?> DeSerializeBinAsync<T>(string fileName)
        {
            return await Task.Run(() =>
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    return (T)binaryFormatter.Deserialize(fs);
                }
            });
        }
    }
}