using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class MyCustomComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            return string.CompareOrdinal(x.Name, y.Name);
        }
    }
}
