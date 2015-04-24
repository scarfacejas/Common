using System;
using System.IO;
using System.Linq;
using Common.Interfaces;

namespace Common
{
    public class SaveToFile<T> : ISavable<T> 
    {
        public string FileFullPath { get; private set; }
        private readonly static object _lockObject = new object();

        public SaveToFile(string fileFullName)
        {
            if (!typeof(T).GetCustomAttributes(true).Any(a => a.GetType() == typeof(SerializableAttribute)))
                throw new InvalidOperationException(string.Format("T must be Serializable.  {0} is not.", typeof(T)));

            FileFullPath = fileFullName;
        }

        public void Save(T toSave)
        {
            lock (_lockObject)
                Serializer.SaveData(FileFullPath, toSave);
        }

        public T Read()
        {
            object o = null;

            lock (_lockObject)
                o = Serializer.GetDeserializedData(FileFullPath);

            return (T) o;
        }

        public void Delete()
        {
            lock (_lockObject)
            {
                if (File.Exists(FileFullPath))
                    File.Delete(FileFullPath);
            }
        }
    }
}
