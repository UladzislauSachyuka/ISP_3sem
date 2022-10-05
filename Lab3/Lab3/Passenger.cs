using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Passenger : IComparable<Passenger> 
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

        private List<Ticket> tickets;
        public List<Ticket> Tickets
        {
            get { return tickets; }
            set { tickets = value; }
        }
        public Passenger(string name_)
        {
            Name = name_;
            Tickets = new List<Ticket>();
        }

        public void Buy(string tariff, int price)
        {
            Tickets.Add(new Ticket(tariff, price));
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
                TotalPrice += tickets[i].Tariff.Price;
            }
            return TotalPrice;
        }

        public int CompareTo(Passenger? other)
        {
            if (other == null)
                return 1;
            return this.GetTotalPrice().CompareTo(other.GetTotalPrice());
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
