using Lab5.Domain;
using _Serializer;
    
namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ISerializer serializer = new Serializer();
            List<Airport> list = new List<Airport>();
            list.Add(new Airport(new Runway { Length = 1500, Name = "Name1", IsOccupied = true }));
            list.Add(new Airport(new Runway { Length = 1600, Name = "Name2", IsOccupied = true }));
            list.Add(new Airport(new Runway { Length = 1700, Name = "Name3", IsOccupied = true }));
            list.Add(new Airport(new Runway { Length = 1400, Name = "Name4", IsOccupied = true }));
            list.Add(new Airport(new Runway { Length = 1800, Name = "Name5", IsOccupied = true }));

            IEnumerable<Airport> list2;

            string linqPath = "linq.xml";
            string xmlPath = "xml.xml";
            string jsonPath = "json.json";

            Console.WriteLine("Serialization by LINQ to XML:");
            serializer.SerializeByLINQ(list, linqPath);
            Console.WriteLine("Created file:");
            Console.WriteLine(File.ReadAllText(linqPath));
            list2 = serializer.DeSerializeByLINQ(linqPath);   
            File.Delete(linqPath);
            list2 = null;

            Console.WriteLine("Serialization by XmlSerializer:");
            serializer.SerializeXML(list, xmlPath);
            Console.WriteLine("Created file:");
            Console.WriteLine(File.ReadAllText(xmlPath));
            list2 = serializer.DeSerializeXML(xmlPath);
            Console.WriteLine("\nDeserialized collection:");
            Console.WriteLine(string.Join("\n", list2) + "\n\n\n");
            File.Delete(xmlPath);
            list2 = null;

            Console.WriteLine("Serialization by JsonSerializer:");
            serializer.SerializeJSON(list, jsonPath);
            Console.WriteLine("Created file:");
            Console.WriteLine(File.ReadAllText(jsonPath));
            list2 = serializer.DeSerializeJSON(jsonPath);
            Console.WriteLine("\nDeserialized collection:");
            Console.WriteLine(string.Join("\n", list2) + "\n\n\n");
            File.Delete(jsonPath);
        }
    }
}