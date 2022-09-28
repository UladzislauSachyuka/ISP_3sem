using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Ticket
    {
        private int price;
        private string tariff;
        public string Tariff
        {
            get { return tariff; }
            set { tariff = value; }
        }
        public Ticket()
        {
            price = 100;
            tariff = "Israel";
        }
        public Ticket(int pr, string t)
        {
            Price = pr;
            tariff = t;
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
    }
}
