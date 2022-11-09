using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }
        public override string ToString()
        {
            return $"{Name} {Age} {IsMarried}";
        }
    }
}
