using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Collections;

namespace Lab2
{
    public class Passenger
    {
        private string name;
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
        public Passenger(string name_)
        {
            Name = name_;
            Tickets = new MyCustomCollection<Ticket>();
        }

        public void Buy(string Tariff, int Price)
        {
            Tickets.Add(new Ticket(Price, Tariff));
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
    }
}
