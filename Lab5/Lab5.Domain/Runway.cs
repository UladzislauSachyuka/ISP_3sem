using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab5.Domain
{
    public class Runway
    {
        [XmlAttribute("Length")]
        public int Length { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("IsOccupied")]
        public bool IsOccupied { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Length: {Length}, IsOccupied: {IsOccupied}";
        }
    }
}
