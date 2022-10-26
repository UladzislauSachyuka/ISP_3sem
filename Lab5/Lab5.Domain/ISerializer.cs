using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Lab5.Domain
{
    public interface ISerializer
    {
        IEnumerable<Airport> DeSerializeByLINQ(string fileName);
        IEnumerable<Airport> DeSerializeXML(string fileName);
        IEnumerable<Airport> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Airport> airports, string fileName);
        void SerializeXML(IEnumerable<Airport> airports, string fileName);
        void SerializeJSON(IEnumerable<Airport> airports, string fileName);
    }
}
