using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Sachivko_Lab1.Collections;

namespace _153502_Sachivko_Lab1
{
    public class Passenger
    {
        private string name;
        public Passenger(string name_)
        {
            name = name_;
            Tickets = new MyCustomCollection<Ticket>();
        }

        public void Buy(Ticket.Tariff Type, int Price)
        {
            Tickets.Add(new Ticket(Price, Type));
            return;
        }
        public void Buy(Ticket ticket)
        {
            Tickets.Add(ticket);
            return;
        }
        public int GetTotalPrice()
        {
            int TotalPrice = 0;
            for (int i = 0; i < tickets.Count; ++i)
            {
                TotalPrice += tickets[i].Price;
            }
            return TotalPrice;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    name = "David Beckham";
                    return;
                }
                name = value;
            }
        }

        private MyCustomCollection<Ticket> tickets;
        public MyCustomCollection<Ticket> Tickets
        {
            get { return tickets; }
            set { tickets = value; }
        }
    }
}
