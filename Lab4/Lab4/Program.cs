using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> list1 = new()
            {
                new() { Name = "BMW", Age = 5, IsElectric = false },
                new() { Name = "Mercedes", Age = 1, IsElectric = false },
                new() { Name = "Audi", Age = 2, IsElectric = true },
                new() { Name = "Skoda", Age = 5, IsElectric = false },
                new() { Name = "Volkswagen", Age = 3, IsElectric = true }
            };

            IFileService<Car> fileService = new FileService();

            fileService.SaveData(list1, "File1");

            File.Move("File1", "File2", true);

            List<Car> list2 = new();

            list2.AddRange(fileService.ReadFile("File2").ToList());

            list2.Sort(new MyCustomComparer());
            Console.WriteLine(string.Join(Environment.NewLine, list2));

            list2.Sort((x, y) => x.Age.CompareTo(y.Age));
            Console.WriteLine(string.Join(Environment.NewLine, list2));

            File.Delete("File2");
        }
    }
}