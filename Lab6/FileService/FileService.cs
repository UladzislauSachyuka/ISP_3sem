using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab6;

namespace _FileService
{
    public class FileService<T> : IFileService<T> where T: class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            return JsonSerializer.Deserialize<IEnumerable<T>>(File.ReadAllText(fileName));
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(data));
        }
    }
}
