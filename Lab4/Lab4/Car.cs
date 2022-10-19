using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Car
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsElectric { get; set; }
        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Is electric:{IsElectric}";
        }
    }
}
