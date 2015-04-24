using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public class Serializer
    {
        public static object GetDeserializedData(string path)
        {
            if (!File.Exists(path))
                return null;

            using (var stream = File.Open(path, FileMode.Open))
            {
                var serializer = new BinaryFormatter();

                return serializer.Deserialize(stream);
            }
        }

        public static void SaveData(string path, object data)
        {
            using (var stream = File.Open(path, FileMode.Create))
            {
                var serializer = new BinaryFormatter();

                serializer.Serialize(stream, data);
            }
        }
    }
}
