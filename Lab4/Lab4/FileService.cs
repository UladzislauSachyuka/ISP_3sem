using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class FileService : IFileService<Car>
    {
        public IEnumerable<Car> ReadFile(string filename)
        {
            if (!File.Exists(filename))
                yield break;
            using BinaryReader binaryReader = new BinaryReader(File.Open(filename, FileMode.Open));

            while (true)
            {
                Car car = new Car();
                try
                {
                    car.Name = binaryReader.ReadString();
                    car.Age = binaryReader.ReadInt32();
                    car.IsElectric = binaryReader.ReadBoolean();
                }
                catch (EndOfStreamException)
                {
                    yield break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    yield break;
                }

                yield return car;
            }
        }
        public void SaveData(IEnumerable<Car> data, string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using BinaryWriter binaryWriter = new BinaryWriter(File.Open(filename, FileMode.Create));

            foreach (var car in data)
            {
                try
                {
                    binaryWriter.Write(car.Name);
                    binaryWriter.Write(car.Age);
                    binaryWriter.Write(car.IsElectric);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
    }
}
