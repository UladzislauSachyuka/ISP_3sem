using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Sachivko_Lab1
{
    public class Ticket
    {
        private int price;

        public enum Tariff
        {
            Israel,
            Cyprus,
            Egypt
        }
        Tariff type;

        public Ticket()
        {
            price = 100;
            type = Tariff.Israel;
        }
        public Ticket(int pr, Tariff t)
        {
            Price = pr;
            type = t;
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

        public Tariff Type 
        { 
            get { return type; } 
            set { type = value; }
        }
    }
}
