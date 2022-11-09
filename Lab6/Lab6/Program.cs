using Lab6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list1 = new()
            {
                new() { Name = "Name1", Age = 27, IsMarried = true },
                new() { Name = "Name3", Age = 38, IsMarried = false },
                new() { Name = "Name2", Age = 43, IsMarried = true },
                new() { Name = "Name5", Age = 24, IsMarried = false },
                new() { Name = "Name4", Age = 32, IsMarried = true }
            };

            Assembly assembly = Assembly.LoadFile(Path.GetFullPath("FileService.dll"));
            var type = assembly.GetType("_FileService.FileService`1")!.MakeGenericType(typeof(Employee));
            var fileService = Activator.CreateInstance(type) as IFileService<Employee>;
            fileService!.SaveData(list1, "list.json");
            var list2 = fileService.ReadFile("list.json");
            Console.WriteLine(string.Join("\n", list2));
        }
    }
}