using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Airport
    {
        public delegate void MessageHandler(string message);
        public event MessageHandler TariffAdded;
        public event MessageHandler PassengerAdded;
        public event MessageHandler TicketPurchase;

        private Dictionary<string, Tariff> tariffs = new Dictionary<string, Tariff>();
        private List<Passenger> passengers;
        private List<Ticket> tickets;

        public Airport() 
        {
            passengers = new List<Passenger>();
            tickets = new List<Ticket>();
        }
        public void AddTariff(string tariff, int price)
        {
            tariffs.Add(tariff, new Tariff(tariff, price));
            TariffAdded?.Invoke($"Tariff {tariff} at the price of {price} was added");
        }
        public void AddPassenger(string name)
        {
            passengers.Add(new Passenger(name));
            PassengerAdded?.Invoke($"Passenger {name} was added");
        }
        public void AddTicket(Ticket ticket)
        {
            tickets.Add(ticket);
        }
        public void AddTicket(string tariff, int price)
        {
            if (tariffs.ContainsKey(tariff))
                tickets.Add(new Ticket(tariff, price));
            else
            {
                Console.WriteLine("There is no such tariff in the airport");
                return;
            }
        }
        public void PrintTotalPrice(string passenger_name)
        {
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == passenger_name)
                {
                    if (passenger.Tickets.Count == 0)
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("{0} has no tickets", passenger.Name);
                        Console.WriteLine("\n################################\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n################################\n");
                        Console.WriteLine("Total price: {0}", passenger.GetTotalPrice());
                        Console.WriteLine("\n################################\n");
                        return;
                    }
                }
            }
            Console.WriteLine("Passenger not found");
            return;
        }
        public void BuyTicket(string passenger_name, string tariff)
        {
            foreach (Passenger passenger in passengers)
            {
                if (passenger.Name == passenger_name)
                {
                    foreach (Ticket ticket in tickets)
                    {
                        if (ticket.Tariff.Rate == tariff)
                        {
                            passenger.Buy(ticket);
                            TicketPurchase?.Invoke($"Passenger {passenger_name} bought ticket to {tariff}");
                            return;
                        }
                    }
                    Console.WriteLine("Ticket not found");
                    Console.WriteLine("Enter the price: ");
                    AddTicket(tariff, Convert.ToInt32(Console.ReadLine()));
                    passenger.Buy(tickets[tickets.Count - 1]);
                    TicketPurchase?.Invoke($"Passenger {passenger_name} bought ticket to {tariff}");
                    return;
                }
            }
            AddPassenger(passenger_name);
            BuyTicket(passenger_name, tariff);
            TicketPurchase?.Invoke($"Passenger {passenger_name} bought ticket to {tariff}");
            return;
        }
        public List<string> GetListOfTariffs()
        {
            var temp = (from entry in tariffs                         
                        orderby entry.Value.Price descending 
                        select entry.Key);

            return temp.ToList();
        }
        public int GetTotalCost()
        {
            int total = 0;
            foreach (Ticket ticket in tickets)
            {
                total += ticket.Tariff.Price;
            }
            return total;
        }
        public string GetPassengerMaxPaid()
        {
            return passengers.Max().Name;
        }
        public int GetNumberOfPassengersWhoPaidMoreThanSetSum(int sum)
        {
            return passengers.Aggregate(0, (number, next) => next.GetTotalPrice() > sum ? number + 1 : number);
        }
        public IEnumerable<(string name, int total)> GroupByRates(string name)
        {
            Passenger passenger = passengers.FirstOrDefault(x => x.Name == name);
            return passenger.Tickets.GroupBy(u => u).Select(u => (u.Key.Tariff.Rate, u.Key.Tariff.Price * u.Count()));
        }
    }
}