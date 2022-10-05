using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Ticket
    {
        private Tariff tariff;
        public Tariff Tariff
        {
            get { return tariff; }
            set { tariff = value; }
        }
        public Ticket()
        {
            Tariff = new Tariff("Israel", 100);
        }
        public Ticket(string t, int price)
        {
            Tariff = new Tariff(t, price);
        }
    }
}
