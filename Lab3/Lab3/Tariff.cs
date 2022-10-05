using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Tariff
    {
        private string rate;
        private int price;
        public string Rate 
        {
            get { return rate; }
            set { rate = value; }
        }
        public int Price
        {
            get { return price; }

            set
            {
                if (value < 0)
                {
                    price = 100;
                    return;
                }
                price = value;
            }
        }
        public Tariff(string rate, int price)
        {
            this.rate = rate;
            this.price = price;
        }
    }
}
