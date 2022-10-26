using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using Lab5.Domain;

namespace _Serializer
{
    public class Serializer : ISerializer
    {
        public IEnumerable<Airport> DeSerializeByLINQ(string fileName)
        {
            XDocument document = XDocument.Load(fileName);
            return document.Element("Airports")?
                .Elements("Airport")
                .Select(e => e.Element("Runway"))
                .Select(e => new Airport(new Runway
                {
                    Length = (int)e?.Attribute("Length"),
                    Name = e?.Attribute("Name").Value,
                    IsOccupied = (bool)e?.Attribute("IsOccupied")
                }));
        }

        public IEnumerable<Airport> DeSerializeXML(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Airport[]));
            using FileStream fileStream = new FileStream(fileName, FileMode.Open);
            return xmlSerializer.Deserialize(fileStream) as IEnumerable<Airport>;
        }

        public IEnumerable<Airport> DeSerializeJSON(string fileName)
        {
            return JsonSerializer.Deserialize<IEnumerable<Airport>>(File.ReadAllText(fileName));
        }

        public void SerializeByLINQ(IEnumerable<Airport> airports, string fileName)
        {
            XDocument document = new XDocument(
                new XElement("Airports",
                    airports.Select(s => s.Runway).Select(o => new XElement("Airport",
                        new XElement("Runway",
                            new XAttribute("Length", o.Length),
                            new XAttribute("Name", o.Name),
                            new XAttribute("IsOccupied", o.IsOccupied))))));
            document.Save(fileName);
        }

        public void SerializeXML(IEnumerable<Airport> airports, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(airports.GetType());
            using FileStream fileStream = new FileStream(fileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, airports);
        }

        public void SerializeJSON(IEnumerable<Airport> airports, string fileName)
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(airports));
        }
    }
}