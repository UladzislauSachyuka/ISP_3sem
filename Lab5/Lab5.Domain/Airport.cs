using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab5.Domain
{
    public class Airport
    {
        [XmlElement("Runway")]
        public Runway Runway { get; set; }
        public Airport()
        {

        }

        public Airport(Runway runway)
        {
            Runway = runway;
        }

        public override string ToString()
        {
            return $"Runway: {Runway}";
        }
    }
}
